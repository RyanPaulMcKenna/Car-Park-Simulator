using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarParkSimulator
{
    public partial class SimulatorInterface : Form
    { 

              
        private TicketMachine ticketMachine;
        private ActiveTickets activeTickets;
        private TicketValidator ticketValidator;
        private Barrier entryBarrier;
        private Barrier exitBarrier;
        private FullSign fullSign;
        private CarPark carPark;
        private EntrySensor entrySensor;
        private ExitSensor exitSensor;
        private Ticket ticket;
        private PayStation payStation;
        /////////////////////////
        public SimulatorInterface()
        {
            InitializeComponent();
        }
        ///////////////////////
        ////// Operations /////
        private void ResetSystem(object sender, EventArgs e)
        {
            activeTickets = new ActiveTickets();
            ticketMachine = new TicketMachine(activeTickets);
            ticketValidator = new TicketValidator(activeTickets);
            entryBarrier = new Barrier();
            exitBarrier = new Barrier();
            fullSign = new FullSign();
            ticket = new Ticket();         
            carPark = new CarPark(ticketMachine, ticketValidator, fullSign, entryBarrier, exitBarrier);
            entrySensor = new EntrySensor(carPark);
            exitSensor = new ExitSensor(carPark);
            payStation = new PayStation();
            //////////////////////////////////////         
            ////////////////////////////////////////
            ticketMachine.AssignCarPark(carPark);
            ticketValidator.AssignCarPark(carPark);
            /////////////////////////////////////////
            /////////////////////////////////////////
            btnCarArrivesAtEntrance.Visible = true;
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = false;
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = false;
            /////////////////////////////////////
            lblEntrySensor.Text = Convert.ToString(entrySensor.IsCarOnSensor());
            lblExitSensor.Text = Convert.ToString(exitSensor.IsCarOnSensor());
            lblEntryBarrier.Text = Convert.ToString(entryBarrier.isLifted());
            lblExitBarrier.Text = Convert.ToString(exitBarrier.isLifted());
            lblFullSign.Text = Convert.ToString(fullSign.IsLit());
            lblSpaces.Text = Convert.ToString(carPark.GetCurrentSpaces());
            lstActiveTickets.Items.Clear();
            UpdateDisplay();
        }
        private void CarArrivesAtEntrance(object sender, EventArgs e)
        {  
            //////////////////////////
            btnCarArrivesAtEntrance.Visible = false;
            btnDriverPressesForTicket.Visible = true;
            //////////////////////////
            entrySensor.CarDetected();          
            //////////////////////////
            lblEntrySensor.Text = Convert.ToString(entrySensor.IsCarOnSensor());
            lblTicketMachine.Text = ticketMachine.GetMessage();          
          
            UpdateDisplay();
        }
        private void DriverPressesForTicket(object sender, EventArgs e)
        {        
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = true;
            //////////////////////////
            carPark.TicketDispensed();      
            /////////////////////////
            lblTicketMachine.Text = ticketMachine.GetMessage();
            lblEntryBarrier.Text = Convert.ToString(entryBarrier.isLifted());
            lstActiveTickets.Items.Add("#" + activeTickets.AddTicket() + ":          " + ticket.IsPaid());
            UpdateDisplay();   
        }
        private void CarEntersCarPark(object sender, EventArgs e)
        { 
            entrySensor.CarLeftSensor();
            //JUST SETTING THE BUTTONS
            //////////////////////////
            btnCarArrivesAtExit.Visible = true; 
            btnCarEntersCarPark.Visible = false;
            if(carPark.HasSpace())
            btnCarArrivesAtEntrance.Visible = true;
            if (carPark.IsFull())
            btnCarArrivesAtEntrance.Visible = false;
            if(exitSensor.IsCarOnSensor() == true)
            btnCarArrivesAtExit.Visible = false; 
            ///////////////////////////             
                       
            ////////////////////////////
            lblTicketMachine.Text = ticketMachine.GetMessage();
            lblEntrySensor.Text = Convert.ToString(entrySensor.IsCarOnSensor());
            lblEntryBarrier.Text = Convert.ToString(entryBarrier.isLifted());
            lblSpaces.Text = Convert.ToString(carPark.GetCurrentSpaces());
            lblFullSign.Text = Convert.ToString(fullSign.IsLit());
            
             UpdateDisplay();            
        }
        private void CarArrivesAtExit(object sender, EventArgs e)
        {                                 
            exitSensor.CarDetected();
            lblTicketValidator.Text = ticketValidator.GetMessage();
            lblExitSensor.Text = Convert.ToString(exitSensor.IsCarOnSensor());     
            btnCarArrivesAtExit.Visible = false;
            btnDriverPays.Visible = true;
            UpdateDisplay();
        }

        private void btnDriverPays_Click(object sender, EventArgs e)
        {
            btnDriverPays.Visible = false;
            btnDriverEntersTicket.Visible = true;
            lblTicketValidator.Text = ticketValidator.Paid();

            lstActiveTickets.Items.Add("#" + payStation.payForTicket(activeTickets) + ":          " + ticket.SetPaid());

            activeTickets.RemoveTicket();
            lstActiveTickets.Items.RemoveAt(0);
        }

        private void DriverEntersTicket(object sender, EventArgs e)
        {                       
            carPark.TicketValidated();           
            //////////////////////////
            lblTicketValidator.Text = ticketValidator.GetMessage();
            lblExitBarrier.Text = Convert.ToString(exitBarrier.isLifted());

            lstActiveTickets.Items.RemoveAt(lstActiveTickets.Items.Count - 1); 

            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = true;
            UpdateDisplay();

        }
        private void CarExitsCarPark(object sender, EventArgs e)
        {   
            exitSensor.CarLeftSensor();
            if(carPark.IsEmpty())           
            btnCarArrivesAtExit.Visible = false;                                     
            else
            btnCarArrivesAtExit.Visible = true;             
            if (carPark.IsFull())
            btnCarArrivesAtEntrance.Visible = false;
            else
            btnCarArrivesAtEntrance.Visible = true;
            btnCarExitsCarPark.Visible = false;
            if (entrySensor.IsCarOnSensor() == true)
            btnCarArrivesAtEntrance.Visible = false;

            lblExitSensor.Text = Convert.ToString(exitSensor.IsCarOnSensor());
            lblTicketValidator.Text = ticketValidator.GetMessage();          
            lblExitBarrier.Text = Convert.ToString(exitBarrier.isLifted());
            lblSpaces.Text = Convert.ToString(carPark.GetCurrentSpaces());
            lblFullSign.Text = Convert.ToString(fullSign.IsLit());                               
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {

        }


    }
}
