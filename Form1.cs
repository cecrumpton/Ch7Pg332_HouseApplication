using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch7Pg332_HouseApplication
{
    public partial class Form1 : Form
    {
        private Location currentLocation;

        Room diningRoom;
        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;
        Outside garden;
        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom); //start in living room?
        }

        private void CreateObjects()
        {
            diningRoom = new Room("Dining Room", "crystal chandelier");
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with a brass knob");
            kitchen = new RoomWithDoor("Kitchen", "steel appliances", "a screen door");
            garden = new Outside("Garden", false);
            frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with a brass knob");
            backYard = new OutsideWithDoor("Back Yard", true, "a screen door");

            diningRoom.Exits = new Location[] { livingRoom, kitchen};
            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };
            garden.Exits = new Location[] { frontYard, backYard };
            frontYard.Exits = new Location[] { backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden};

            livingRoom.DoorLocation = frontYard;
            kitchen.DoorLocation = backYard;
            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            if (currentLocation is IHasExteriorDoor) //not necessary but added to be double safe
            {
                IHasExteriorDoor locationWithDoor = currentLocation as IHasExteriorDoor;
                MoveToANewLocation(locationWithDoor.DoorLocation);
            }
        }

        private void MoveToANewLocation(Location location)
        {
            currentLocation = location;
            exits.Items.Clear();
            foreach (Location exit in currentLocation.Exits)
                exits.Items.Add(exit.Name);
            exits.SelectedIndex = 0;
            description.Text = currentLocation.Description;
            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            //should remove since it isn't needed
        }

        private void exits_SelectedIndexChanged(object sender, EventArgs e)
        {
            //should remove since it isn't needed
        }
    }
}
