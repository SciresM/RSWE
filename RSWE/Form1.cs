using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;

namespace RSWE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.AllowDrop = true;
            InitializeComponent();
            spec = new ComboBox[] 
            {
                CB_Grass1, CB_Grass2, CB_Grass3, CB_Grass4, CB_Grass5, CB_Grass6, CB_Grass7, CB_Grass8, CB_Grass9, CB_Grass10, CB_Grass11, CB_Grass12,
                CB_TallGrass1, CB_TallGrass2, CB_TallGrass3, CB_TallGrass4, CB_TallGrass5, CB_TallGrass6, CB_TallGrass7, CB_TallGrass8, CB_TallGrass9, CB_TallGrass10, CB_TallGrass11, CB_TallGrass12,
                CB_Swarm1, CB_Swarm2, CB_Swarm3, 
                CB_Surf1, CB_Surf2, CB_Surf3, CB_Surf4, CB_Surf5, 
                CB_RockSmash1, CB_RockSmash2, CB_RockSmash3, CB_RockSmash4, CB_RockSmash5, 
                CB_Old1, CB_Old2, CB_Old3, 
                CB_Good1, CB_Good2, CB_Good3,
                CB_Super1, CB_Super2, CB_Super3,
                CB_HordeA1, CB_HordeA2, CB_HordeA3, CB_HordeA4, CB_HordeA5,
                CB_HordeB1, CB_HordeB2, CB_HordeB3, CB_HordeB4, CB_HordeB5,
                CB_HordeC1, CB_HordeC2, CB_HordeC3, CB_HordeC4, CB_HordeC5,
            };
            min = new NumericUpDown[]
            {
                NUP_GrassMin1, NUP_GrassMin2, NUP_GrassMin3, NUP_GrassMin4, NUP_GrassMin5, NUP_GrassMin6, NUP_GrassMin7, NUP_GrassMin8, NUP_GrassMin9, NUP_GrassMin10, NUP_GrassMin11, NUP_GrassMin12,
                NUP_TallGrassMin1, NUP_TallGrassMin2, NUP_TallGrassMin3, NUP_TallGrassMin4, NUP_TallGrassMin5, NUP_TallGrassMin6, NUP_TallGrassMin7, NUP_TallGrassMin8, NUP_TallGrassMin9, NUP_TallGrassMin10, NUP_TallGrassMin11, NUP_TallGrassMin12,
                NUP_SwarmMin1, NUP_SwarmMin2, NUP_SwarmMin3, 
                NUP_SurfMin1, NUP_SurfMin2, NUP_SurfMin3, NUP_SurfMin4, NUP_SurfMin5, 
                NUP_RockSmashMin1, NUP_RockSmashMin2, NUP_RockSmashMin3, NUP_RockSmashMin4, NUP_RockSmashMin5, 
                NUP_OldMin1, NUP_OldMin2, NUP_OldMin3, 
                NUP_GoodMin1, NUP_GoodMin2, NUP_GoodMin3,
                NUP_SuperMin1, NUP_SuperMin2, NUP_SuperMin3,
                NUP_HordeAMin1, NUP_HordeAMin2, NUP_HordeAMin3, NUP_HordeAMin4, NUP_HordeAMin5,
                NUP_HordeBMin1, NUP_HordeBMin2, NUP_HordeBMin3, NUP_HordeBMin4, NUP_HordeBMin5,
                NUP_HordeCMin1, NUP_HordeCMin2, NUP_HordeCMin3, NUP_HordeCMin4, NUP_HordeCMin5,
            };
            max = new NumericUpDown[]
            {
                NUP_GrassMax1, NUP_GrassMax2, NUP_GrassMax3, NUP_GrassMax4, NUP_GrassMax5, NUP_GrassMax6, NUP_GrassMax7, NUP_GrassMax8, NUP_GrassMax9, NUP_GrassMax10, NUP_GrassMax11, NUP_GrassMax12,
                NUP_TallGrassMax1, NUP_TallGrassMax2, NUP_TallGrassMax3, NUP_TallGrassMax4, NUP_TallGrassMax5, NUP_TallGrassMax6, NUP_TallGrassMax7, NUP_TallGrassMax8, NUP_TallGrassMax9, NUP_TallGrassMax10, NUP_TallGrassMax11, NUP_TallGrassMax12,
                NUP_SwarmMax1, NUP_SwarmMax2, NUP_SwarmMax3, 
                NUP_SurfMax1, NUP_SurfMax2, NUP_SurfMax3, NUP_SurfMax4, NUP_SurfMax5, 
                NUP_RockSmashMax1, NUP_RockSmashMax2, NUP_RockSmashMax3, NUP_RockSmashMax4, NUP_RockSmashMax5, 
                NUP_OldMax1, NUP_OldMax2, NUP_OldMax3, 
                NUP_GoodMax1, NUP_GoodMax2, NUP_GoodMax3,
                NUP_SuperMax1, NUP_SuperMax2, NUP_SuperMax3,
                NUP_HordeAMax1, NUP_HordeAMax2, NUP_HordeAMax3, NUP_HordeAMax4, NUP_HordeAMax5,
                NUP_HordeBMax1, NUP_HordeBMax2, NUP_HordeBMax3, NUP_HordeBMax4, NUP_HordeBMax5,
                NUP_HordeCMax1, NUP_HordeCMax2, NUP_HordeCMax3, NUP_HordeCMax4, NUP_HordeCMax5,
            };
            form = new NumericUpDown[]
            {
                NUP_GrassForme1, NUP_GrassForme2, NUP_GrassForme3, NUP_GrassForme4, NUP_GrassForme5, NUP_GrassForme6, NUP_GrassForme7, NUP_GrassForme8, NUP_GrassForme9, NUP_GrassForme10, NUP_GrassForme11, NUP_GrassForme12,
                NUP_TallGrassForme1, NUP_TallGrassForme2, NUP_TallGrassForme3, NUP_TallGrassForme4, NUP_TallGrassForme5, NUP_TallGrassForme6, NUP_TallGrassForme7, NUP_TallGrassForme8, NUP_TallGrassForme9, NUP_TallGrassForme10, NUP_TallGrassForme11, NUP_TallGrassForme12,
                NUP_SwarmForme1, NUP_SwarmForme2, NUP_SwarmForme3, 
                NUP_SurfForme1, NUP_SurfForme2, NUP_SurfForme3, NUP_SurfForme4, NUP_SurfForme5, 
                NUP_RockSmashForme1, NUP_RockSmashForme2, NUP_RockSmashForme3, NUP_RockSmashForme4, NUP_RockSmashForme5, 
                NUP_OldForme1, NUP_OldForme2, NUP_OldForme3, 
                NUP_GoodForme1, NUP_GoodForme2, NUP_GoodForme3,
                NUP_SuperForme1, NUP_SuperForme2, NUP_SuperForme3,
                NUP_HordeAForme1, NUP_HordeAForme2, NUP_HordeAForme3, NUP_HordeAForme4, NUP_HordeAForme5,
                NUP_HordeBForme1, NUP_HordeBForme2, NUP_HordeBForme3, NUP_HordeBForme4, NUP_HordeBForme5,
                NUP_HordeCForme1, NUP_HordeCForme2, NUP_HordeCForme3, NUP_HordeCForme4, NUP_HordeCForme5,
            };
        }
        private ComboBox[] spec;
        private NumericUpDown[] min;
        private NumericUpDown[] max;
        private NumericUpDown[] form;
        string[] specieslist = { };
        string[] metRS_00000 = { };
        byte[] zonedata = { };
        byte[] decStorage = { };
        string[] LocationNames = { };
        private string[] encdatapaths;
        private string[] filepaths;

        private void Form1_Load(object sender, EventArgs e)
        {
            specieslist = getStringList("Species", "en");
            specieslist[0] = "---";
            #region Forme List Initialization
            this.CB_FormeList.Items.AddRange(new string[] {"Unown-A - 0",
            "Unown-B - 1",
            "Unown-C - 2",
            "Unown-D - 3",
            "Unown-E - 4",
            "Unown-F - 5",
            "Unown-G - 6",
            "Unown-H - 7",
            "Unown-I - 8",
            "Unown-J - 9",
            "Unown-K - 10",
            "Unown-L - 11",
            "Unown-M - 12",
            "Unown-N - 13",
            "Unown-O - 14",
            "Unown-P - 15",
            "Unown-Q - 16",
            "Unown-R - 17",
            "Unown-S - 18",
            "Unown-T - 19",
            "Unown-U - 20",
            "Unown-V - 21",
            "Unown-W - 22",
            "Unown-X - 23",
            "Unown-Y - 24",
            "Unown-Z - 25",
            "Unown-! - 26",
            "Unown-? - 27",
            "",
            "Castform-Normal - 0",
            "Castform-Sunny - 1",
            "Castform-Rainy - 2",
            "Castform-Snowy - 3",
            "",
            "Deoxys-Normal - 0",
            "Deoxys-Attack - 1",
            "Deoxys-Defense - 2",
            "Deoxys-Speed - 3",
            "",
            "Burmy-Plant Cloak - 0",
            "Burmy-Sandy Cloak - 1",
            "Burmy-Trash Cloak - 2",
            "",
            "Wormadam-Plant Cloak - 0",
            "Wormadam-Sandy Cloak - 1",
            "Wormadam-Trash Cloak - 2",
            "",
            "Cherrim-Overcast - 0",
            "Cherrim-Sunshine - 1",
            "",
            "Shellos-West Sea - 0",
            "Shellos-East Sea - 1",
            "",
            "Gastrodon-West Sea - 0",
            "Gastrodon-East Sea - 1",
            "",
            "Rotom-Normal - 0",
            "Rotom-Heat - 1",
            "Rotom-Wash - 2",
            "Rotom-Frost - 3",
            "Rotom-Fan - 4",
            "Rotom-Mow - 5",
            "",
            "Giratina-Altered - 0",
            "Giratina-Origin - 1",
            "",
            "Shaymin-Land - 0",
            "Shaymin-Sky - 1",
            "",
            "Arceus-Normal - 0",
            "Arceus-Fighting - 1",
            "Arceus-Flying - 2",
            "Arceus-Poison - 3",
            "Arceus-Ground - 4",
            "Arceus-Rock - 5",
            "Arceus-Bug - 6",
            "Arceus-Ghost - 7",
            "Arceus-Steel - 8",
            "Arceus-Fire - 9",
            "Arceus-Water - 10",
            "Arceus-Grass - 11",
            "Arceus-Electric - 12",
            "Arceus-Psychic - 13",
            "Arceus-Ice - 14",
            "Arceus-Dragon - 15",
            "Arceus-Dark - 16",
            "",
            "Basculin-Red-Striped - 0",
            "Basculin-Blue-Striped - 1",
            "",
            "Darmanitan-Standard Mode - 0",
            "Darmanitan-Zen Mode - 1",
            "",
            "Deerling-Spring - 0",
            "Deerling-Summer - 1",
            "Deerling-Autumn - 2",
            "Deerling-Winter - 3",
            "",
            "Sawsbuck-Spring - 0",
            "Sawsbuck-Summer - 1",
            "Sawsbuck-Autumn - 2",
            "Sawsbuck-Winter - 3",
            "",
            "Tornadus-Incarnate - 0",
            "Tornadus-Therian - 1",
            "",
            "Thundurus-Incarnate - 0",
            "Thundurus-Therian - 1",
            "",
            "Landorus-Incarnate - 0",
            "Landorus-Therian - 1",
            "",
            "Kyurem-Normal - 0",
            "Kyurem-White - 1",
            "Kyurem-Black - 2",
            "",
            "Keldeo-Usual - 0",
            "Keldeo-Resolution - 1",
            "",
            "Meloetta-Aria - 0",
            "Meloetta-Pirouette - 1",
            "",
            "Genesect-Normal - 0",
            "Genesect-Water - 1",
            "Genesect-Electric - 2",
            "Genesect-Fire - 3",
            "Genesect-Ice - 4",
            "",
            "Flabebe-Red - 0",
            "Flabebe-Yellow - 1",
            "Flabebe-Orange - 2",
            "Flabebe-Blue - 3",
            "Flabebe-White - 4",
            "",
            "Floette-Red - 0",
            "Floette-Yellow - 1",
            "Floette-Orange - 2",
            "Floette-Blue - 3",
            "Floette-Wite - 4",
            "Floette-Eternal - 5",
            "",
            "Florges-Red - 0",
            "Florges-Yellow - 1",
            "Florges-Orange - 2",
            "Florges-Blue - 3",
            "Florges-White - 4",
            "",
            "Furfrou- Natural - 0",
            "Furfrou- Heart - 1",
            "Furfrou- Star - 2",
            "Furfrou- Diamond - 3",
            "Furfrou- Deputante - 4",
            "Furfrou- Matron - 5",
            "Furfrou- Dandy - 6",
            "Furfrou- La Reine- 7",
            "Furfrou- Kabuki - 8",
            "Furfrou- Pharaoh - 9",
            "",
            "Aegislash- Shield - 0",
            "Aegislash- Blade - 0",
            "",
            "Vivillon-Icy Snow - 0",
            "Vivillon-Polar - 1",
            "Vivillon-Tundra - 2",
            "Vivillon-Continental  - 3",
            "Vivillon-Garden - 4",
            "Vivillon-Elegant - 5",
            "Vivillon-Meadow - 6",
            "Vivillon-Modern  - 7",
            "Vivillon-Marine - 8",
            "Vivillon-Archipelago - 9",
            "Vivillon-High-Plains - 10",
            "Vivillon-Sandstorm - 11",
            "Vivillon-River - 12",
            "Vivillon-Monsoon - 13",
            "Vivillon-Savannah  - 14",
            "Vivillon-Sun - 15",
            "Vivillon-Ocean - 16",
            "Vivillon-Jungle - 17",
            "Vivillon-Fancy - 18",
            "Vivillon-Poké Ball - 19",
            "",
            "Pumpkaboo/Gourgeist-Small - 0",
            "Pumpkaboo/Gourgeist-Average - 1",
            "Pumpkaboo/Gourgeist-Large - 2",
            "Pumpkaboo/Gourgeist-Super - 3",
            "",
            "Hoopa-Normal - 0",
            "Hoopa-Unbound - 1",
            "",
            "Megas-Normal - 0",
            "Megas-Mega (X) - 1",
            "Megas-Mega (Y) - 2"
            });
            #endregion
            #region Clear Default Data
            CB_Grass1.Items.Clear();
            CB_Grass2.Items.Clear();
            CB_Grass3.Items.Clear();
            CB_Grass4.Items.Clear();
            CB_Grass5.Items.Clear();
            CB_Grass6.Items.Clear();
            CB_Grass7.Items.Clear();
            CB_Grass8.Items.Clear();
            CB_Grass9.Items.Clear();
            CB_Grass10.Items.Clear();
            CB_Grass11.Items.Clear();
            CB_Grass12.Items.Clear();
            CB_TallGrass1.Items.Clear();
            CB_TallGrass2.Items.Clear();
            CB_TallGrass3.Items.Clear();
            CB_TallGrass4.Items.Clear();
            CB_TallGrass5.Items.Clear();
            CB_TallGrass6.Items.Clear();
            CB_TallGrass7.Items.Clear();
            CB_TallGrass8.Items.Clear();
            CB_TallGrass9.Items.Clear();
            CB_TallGrass10.Items.Clear();
            CB_TallGrass11.Items.Clear();
            CB_TallGrass12.Items.Clear();
            CB_Swarm1.Items.Clear();
            CB_Swarm2.Items.Clear();
            CB_Swarm3.Items.Clear();
            CB_Surf1.Items.Clear();
            CB_Surf2.Items.Clear();
            CB_Surf3.Items.Clear();
            CB_Surf4.Items.Clear();
            CB_Surf5.Items.Clear();
            CB_RockSmash1.Items.Clear();
            CB_RockSmash2.Items.Clear();
            CB_RockSmash3.Items.Clear();
            CB_RockSmash4.Items.Clear();
            CB_RockSmash5.Items.Clear();
            CB_Old1.Items.Clear();
            CB_Old2.Items.Clear();
            CB_Old3.Items.Clear();
            CB_Good1.Items.Clear();
            CB_Good2.Items.Clear();
            CB_Good3.Items.Clear();
            CB_Super1.Items.Clear();
            CB_Super2.Items.Clear();
            CB_Super3.Items.Clear();
            CB_HordeA1.Items.Clear();
            CB_HordeA2.Items.Clear();
            CB_HordeA3.Items.Clear();
            CB_HordeA4.Items.Clear();
            CB_HordeA5.Items.Clear();
            CB_HordeB1.Items.Clear();
            CB_HordeB2.Items.Clear();
            CB_HordeB3.Items.Clear();
            CB_HordeB4.Items.Clear();
            CB_HordeB5.Items.Clear();
            CB_HordeC1.Items.Clear();
            CB_HordeC2.Items.Clear();
            CB_HordeC3.Items.Clear();
            CB_HordeC4.Items.Clear();
            CB_HordeC5.Items.Clear();

            #endregion
            #region Add Data to Boxes
            foreach (string s in specieslist)
            {
                CB_Grass1.Items.Add(s);
                CB_Swarm1.Items.Add(s);
                CB_TallGrass1.Items.Add(s);
                CB_Grass2.Items.Add(s);
                CB_Swarm2.Items.Add(s);
                CB_TallGrass2.Items.Add(s);
                CB_Grass3.Items.Add(s);
                CB_Swarm3.Items.Add(s);
                CB_TallGrass3.Items.Add(s);
                CB_Grass4.Items.Add(s);
                CB_TallGrass4.Items.Add(s);
                CB_Grass5.Items.Add(s);
                CB_TallGrass5.Items.Add(s);
                CB_Grass6.Items.Add(s);
                CB_TallGrass6.Items.Add(s);
                CB_Grass7.Items.Add(s);
                CB_TallGrass7.Items.Add(s);
                CB_Grass8.Items.Add(s);
                CB_TallGrass8.Items.Add(s);
                CB_Grass9.Items.Add(s);
                CB_TallGrass9.Items.Add(s);
                CB_Grass10.Items.Add(s);
                CB_TallGrass10.Items.Add(s);
                CB_Grass11.Items.Add(s);
                CB_TallGrass11.Items.Add(s);
                CB_Grass12.Items.Add(s);
                CB_TallGrass12.Items.Add(s);
                CB_Surf1.Items.Add(s);
                CB_RockSmash1.Items.Add(s);
                CB_HordeA1.Items.Add(s);
                CB_HordeB1.Items.Add(s);
                CB_HordeC1.Items.Add(s);
                CB_Surf2.Items.Add(s);
                CB_RockSmash2.Items.Add(s);
                CB_HordeA2.Items.Add(s);
                CB_HordeB2.Items.Add(s);
                CB_HordeC2.Items.Add(s);
                CB_Surf3.Items.Add(s);
                CB_RockSmash3.Items.Add(s);
                CB_HordeA3.Items.Add(s);
                CB_HordeB3.Items.Add(s);
                CB_HordeC3.Items.Add(s);
                CB_Surf4.Items.Add(s);
                CB_RockSmash4.Items.Add(s);
                CB_HordeA4.Items.Add(s);
                CB_HordeB4.Items.Add(s);
                CB_HordeC4.Items.Add(s);
                CB_Surf5.Items.Add(s);
                CB_RockSmash5.Items.Add(s);
                CB_HordeA5.Items.Add(s);
                CB_HordeB5.Items.Add(s);
                CB_HordeC5.Items.Add(s);
                CB_Old1.Items.Add(s);
                CB_Good1.Items.Add(s);
                CB_Super1.Items.Add(s);
                CB_Old2.Items.Add(s);
                CB_Good2.Items.Add(s);
                CB_Super2.Items.Add(s);
                CB_Old3.Items.Add(s);
                CB_Good3.Items.Add(s);
                CB_Super3.Items.Add(s);
            }
            CB_Grass1.SelectedIndex = 0;
            CB_Swarm1.SelectedIndex = 0;
            CB_TallGrass1.SelectedIndex = 0;
            CB_Grass2.SelectedIndex = 0;
            CB_Swarm2.SelectedIndex = 0;
            CB_TallGrass2.SelectedIndex = 0;
            CB_Grass3.SelectedIndex = 0;
            CB_Swarm3.SelectedIndex = 0;
            CB_TallGrass3.SelectedIndex = 0;
            CB_Grass4.SelectedIndex = 0;
            CB_TallGrass4.SelectedIndex = 0;
            CB_Grass5.SelectedIndex = 0;
            CB_TallGrass5.SelectedIndex = 0;
            CB_Grass6.SelectedIndex = 0;
            CB_TallGrass6.SelectedIndex = 0;
            CB_Grass7.SelectedIndex = 0;
            CB_TallGrass7.SelectedIndex = 0;
            CB_Grass8.SelectedIndex = 0;
            CB_TallGrass8.SelectedIndex = 0;
            CB_Grass9.SelectedIndex = 0;
            CB_TallGrass9.SelectedIndex = 0;
            CB_Grass10.SelectedIndex = 0;
            CB_TallGrass10.SelectedIndex = 0;
            CB_Grass11.SelectedIndex = 0;
            CB_TallGrass11.SelectedIndex = 0;
            CB_Grass12.SelectedIndex = 0;
            CB_TallGrass12.SelectedIndex = 0;
            CB_Surf1.SelectedIndex = 0;
            CB_RockSmash1.SelectedIndex = 0;
            CB_HordeA1.SelectedIndex = 0;
            CB_HordeB1.SelectedIndex = 0;
            CB_HordeC1.SelectedIndex = 0;
            CB_Surf2.SelectedIndex = 0;
            CB_RockSmash2.SelectedIndex = 0;
            CB_HordeA2.SelectedIndex = 0;
            CB_HordeB2.SelectedIndex = 0;
            CB_HordeC2.SelectedIndex = 0;
            CB_Surf3.SelectedIndex = 0;
            CB_RockSmash3.SelectedIndex = 0;
            CB_HordeA3.SelectedIndex = 0;
            CB_HordeB3.SelectedIndex = 0;
            CB_HordeC3.SelectedIndex = 0;
            CB_Surf4.SelectedIndex = 0;
            CB_RockSmash4.SelectedIndex = 0;
            CB_HordeA4.SelectedIndex = 0;
            CB_HordeB4.SelectedIndex = 0;
            CB_HordeC4.SelectedIndex = 0;
            CB_Surf5.SelectedIndex = 0;
            CB_RockSmash5.SelectedIndex = 0;
            CB_HordeA5.SelectedIndex = 0;
            CB_HordeB5.SelectedIndex = 0;
            CB_HordeC5.SelectedIndex = 0;
            CB_Old1.SelectedIndex = 0;
            CB_Good1.SelectedIndex = 0;
            CB_Super1.SelectedIndex = 0;
            CB_Old2.SelectedIndex = 0;
            CB_Good2.SelectedIndex = 0;
            CB_Super2.SelectedIndex = 0;
            CB_Old3.SelectedIndex = 0;
            CB_Good3.SelectedIndex = 0;
            CB_Super3.SelectedIndex = 0;
            #endregion
            //Preload Tabs
            PreloadTabs();
        }

        private string[] getStringList(string f, string l)
        {
            object txt = Properties.Resources.ResourceManager.GetObject("text_" + f + "_" + l); // Fetch File, \n to list.
            List<string> rawlist = ((string)txt).Split(new char[] { '\n' }).ToList();

            string[] stringdata = new string[rawlist.Count];
            for (int i = 0; i < rawlist.Count; i++)
                stringdata[i] = rawlist[i].Trim();

            return stringdata;
        }

        private void B_Open_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            openQuick(folderBrowserDialog.SelectedPath);
        }
        private void openQuick(string folder)
        {
            encdatapaths = Directory.GetFiles(folder, "*.*", SearchOption.TopDirectoryOnly);
            Array.Sort(encdatapaths);
            this.filepaths = new string[this.encdatapaths.Length - 2];
            Array.Copy(this.encdatapaths, 2, this.filepaths, 0, this.filepaths.Length);
            #region Data Verification
            //Verify that data is legitimate
            if (!this.encdatapaths[0].Contains("536.bin")) // first file is zonedata data
            {
                return;
            }
            if (!this.encdatapaths[1].Contains("537.EN") && !this.encdatapaths[1].Contains("537.bin")) // second file is ENCOUNTER 2pack
            {
                return;
            }
            foreach (string s in filepaths)
            {
                if (!s.Contains("dec_")) { return; } //Check that all files are of form dec_*
            }
            if (this.encdatapaths.Length != 538) //Check that there are exactly 538 files
            {
                return;
            }
            #endregion
            metRS_00000 = getStringList("rs_00000", "en");
            zonedata = File.ReadAllBytes(encdatapaths[0]);
            decStorage = File.ReadAllBytes(encdatapaths[1]);
            LocationNames = new string[this.filepaths.Length];
            for (int f = 0; f < filepaths.Length; f++)
            {
                string name = Path.GetFileNameWithoutExtension(filepaths[f]);

                int LocationNum = Convert.ToInt16(name.Substring(4, name.Length - 4));
                int indNum = LocationNum * 56 + 0x1C;
                string LocationName = metRS_00000[zonedata[indNum] + (0x100 * (zonedata[indNum + 1] & 1))];
                LocationNames[f] = (LocationNum.ToString("000") + " - " + LocationName);
            }
            CB_LocationID.DataSource = LocationNames;
            B_Open.Enabled = false;
            B_Save.Enabled = true;
            CB_LocationID.Enabled = true;
            CB_LocationID_SelectedIndexChanged(null, null);
        }

        private bool needsInsertion(int mapID)
        {
            if (mapID != 535) // Hardcoded, bad, I know.
                return (BitConverter.ToUInt32(decStorage, (mapID + 2) * 4) - BitConverter.ToUInt32(decStorage, (mapID + 1) * 4) == 0);
            else
                return (BitConverter.ToUInt32(decStorage, (mapID + 1) * 4) == decStorage.Length);
        }

        private bool hasData()
        {
            #region CheckFornon0Vals
            if (CB_Grass1.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme1.Value > 0) { return true; }
            if (NUP_GrassMin1.Value > 0) { return true; }
            if (NUP_GrassMax1.Value > 0) { return true; }
            if (CB_Grass2.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme2.Value > 0) { return true; }
            if (NUP_GrassMin2.Value > 0) { return true; }
            if (NUP_GrassMax2.Value > 0) { return true; }
            if (CB_Grass3.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme3.Value > 0) { return true; }
            if (NUP_GrassMin3.Value > 0) { return true; }
            if (NUP_GrassMax3.Value > 0) { return true; }
            if (CB_Grass4.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme4.Value > 0) { return true; }
            if (NUP_GrassMin4.Value > 0) { return true; }
            if (NUP_GrassMax4.Value > 0) { return true; }
            if (CB_Grass5.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme5.Value > 0) { return true; }
            if (NUP_GrassMin5.Value > 0) { return true; }
            if (NUP_GrassMax5.Value > 0) { return true; }
            if (CB_Grass6.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme6.Value > 0) { return true; }
            if (NUP_GrassMin6.Value > 0) { return true; }
            if (NUP_GrassMax6.Value > 0) { return true; }
            if (CB_Grass7.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme7.Value > 0) { return true; }
            if (NUP_GrassMin7.Value > 0) { return true; }
            if (NUP_GrassMax7.Value > 0) { return true; }
            if (CB_Grass8.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme8.Value > 0) { return true; }
            if (NUP_GrassMin8.Value > 0) { return true; }
            if (NUP_GrassMax8.Value > 0) { return true; }
            if (CB_Grass9.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme9.Value > 0) { return true; }
            if (NUP_GrassMin9.Value > 0) { return true; }
            if (NUP_GrassMax9.Value > 0) { return true; }
            if (CB_Grass10.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme10.Value > 0) { return true; }
            if (NUP_GrassMin10.Value > 0) { return true; }
            if (NUP_GrassMax10.Value > 0) { return true; }
            if (CB_Grass11.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme11.Value > 0) { return true; }
            if (NUP_GrassMin11.Value > 0) { return true; }
            if (NUP_GrassMax11.Value > 0) { return true; }
            if (CB_Grass12.SelectedIndex > 0) { return true; }
            if (NUP_GrassForme12.Value > 0) { return true; }
            if (NUP_GrassMin12.Value > 0) { return true; }
            if (NUP_GrassMax12.Value > 0) { return true; }
            if (CB_TallGrass1.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme1.Value > 0) { return true; }
            if (NUP_TallGrassMin1.Value > 0) { return true; }
            if (NUP_TallGrassMax1.Value > 0) { return true; }
            if (CB_TallGrass2.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme2.Value > 0) { return true; }
            if (NUP_TallGrassMin2.Value > 0) { return true; }
            if (NUP_TallGrassMax2.Value > 0) { return true; }
            if (CB_TallGrass3.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme3.Value > 0) { return true; }
            if (NUP_TallGrassMin3.Value > 0) { return true; }
            if (NUP_TallGrassMax3.Value > 0) { return true; }
            if (CB_TallGrass4.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme4.Value > 0) { return true; }
            if (NUP_TallGrassMin4.Value > 0) { return true; }
            if (NUP_TallGrassMax4.Value > 0) { return true; }
            if (CB_TallGrass5.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme5.Value > 0) { return true; }
            if (NUP_TallGrassMin5.Value > 0) { return true; }
            if (NUP_TallGrassMax5.Value > 0) { return true; }
            if (CB_TallGrass6.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme6.Value > 0) { return true; }
            if (NUP_TallGrassMin6.Value > 0) { return true; }
            if (NUP_TallGrassMax6.Value > 0) { return true; }
            if (CB_TallGrass7.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme7.Value > 0) { return true; }
            if (NUP_TallGrassMin7.Value > 0) { return true; }
            if (NUP_TallGrassMax7.Value > 0) { return true; }
            if (CB_TallGrass8.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme8.Value > 0) { return true; }
            if (NUP_TallGrassMin8.Value > 0) { return true; }
            if (NUP_TallGrassMax8.Value > 0) { return true; }
            if (CB_TallGrass9.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme9.Value > 0) { return true; }
            if (NUP_TallGrassMin9.Value > 0) { return true; }
            if (NUP_TallGrassMax9.Value > 0) { return true; }
            if (CB_TallGrass10.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme10.Value > 0) { return true; }
            if (NUP_TallGrassMin10.Value > 0) { return true; }
            if (NUP_TallGrassMax10.Value > 0) { return true; }
            if (CB_TallGrass11.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme11.Value > 0) { return true; }
            if (NUP_TallGrassMin11.Value > 0) { return true; }
            if (NUP_TallGrassMax11.Value > 0) { return true; }
            if (CB_TallGrass12.SelectedIndex > 0) { return true; }
            if (NUP_TallGrassForme12.Value > 0) { return true; }
            if (NUP_TallGrassMin12.Value > 0) { return true; }
            if (NUP_TallGrassMax12.Value > 0) { return true; }
            if (CB_Swarm1.SelectedIndex > 0) { return true; }
            if (NUP_SwarmForme1.Value > 0) { return true; }
            if (NUP_SwarmMin1.Value > 0) { return true; }
            if (NUP_SwarmMax1.Value > 0) { return true; }
            if (CB_Swarm2.SelectedIndex > 0) { return true; }
            if (NUP_SwarmForme2.Value > 0) { return true; }
            if (NUP_SwarmMin2.Value > 0) { return true; }
            if (NUP_SwarmMax2.Value > 0) { return true; }
            if (CB_Swarm3.SelectedIndex > 0) { return true; }
            if (NUP_SwarmForme3.Value > 0) { return true; }
            if (NUP_SwarmMin3.Value > 0) { return true; }
            if (NUP_SwarmMax3.Value > 0) { return true; }
            if (CB_Surf1.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme1.Value > 0) { return true; }
            if (NUP_SurfMin1.Value > 0) { return true; }
            if (NUP_SurfMax1.Value > 0) { return true; }
            if (CB_Surf2.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme2.Value > 0) { return true; }
            if (NUP_SurfMin2.Value > 0) { return true; }
            if (NUP_SurfMax2.Value > 0) { return true; }
            if (CB_Surf3.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme3.Value > 0) { return true; }
            if (NUP_SurfMin3.Value > 0) { return true; }
            if (NUP_SurfMax3.Value > 0) { return true; }
            if (CB_Surf4.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme4.Value > 0) { return true; }
            if (NUP_SurfMin4.Value > 0) { return true; }
            if (NUP_SurfMax4.Value > 0) { return true; }
            if (CB_Surf5.SelectedIndex > 0) { return true; }
            if (NUP_SurfForme5.Value > 0) { return true; }
            if (NUP_SurfMin5.Value > 0) { return true; }
            if (NUP_SurfMax5.Value > 0) { return true; }
            if (CB_RockSmash1.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme1.Value > 0) { return true; }
            if (NUP_RockSmashMin1.Value > 0) { return true; }
            if (NUP_RockSmashMax1.Value > 0) { return true; }
            if (CB_RockSmash2.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme2.Value > 0) { return true; }
            if (NUP_RockSmashMin2.Value > 0) { return true; }
            if (NUP_RockSmashMax2.Value > 0) { return true; }
            if (CB_RockSmash3.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme3.Value > 0) { return true; }
            if (NUP_RockSmashMin3.Value > 0) { return true; }
            if (NUP_RockSmashMax3.Value > 0) { return true; }
            if (CB_RockSmash4.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme4.Value > 0) { return true; }
            if (NUP_RockSmashMin4.Value > 0) { return true; }
            if (NUP_RockSmashMax4.Value > 0) { return true; }
            if (CB_RockSmash5.SelectedIndex > 0) { return true; }
            if (NUP_RockSmashForme5.Value > 0) { return true; }
            if (NUP_RockSmashMin5.Value > 0) { return true; }
            if (NUP_RockSmashMax5.Value > 0) { return true; }
            if (CB_Old1.SelectedIndex > 0) { return true; }
            if (NUP_OldForme1.Value > 0) { return true; }
            if (NUP_OldMin1.Value > 0) { return true; }
            if (NUP_OldMax1.Value > 0) { return true; }
            if (CB_Old2.SelectedIndex > 0) { return true; }
            if (NUP_OldForme2.Value > 0) { return true; }
            if (NUP_OldMin2.Value > 0) { return true; }
            if (NUP_OldMax2.Value > 0) { return true; }
            if (CB_Old3.SelectedIndex > 0) { return true; }
            if (NUP_OldForme3.Value > 0) { return true; }
            if (NUP_OldMin3.Value > 0) { return true; }
            if (NUP_OldMax3.Value > 0) { return true; }
            if (CB_Good1.SelectedIndex > 0) { return true; }
            if (NUP_GoodForme1.Value > 0) { return true; }
            if (NUP_GoodMin1.Value > 0) { return true; }
            if (NUP_GoodMax1.Value > 0) { return true; }
            if (CB_Good2.SelectedIndex > 0) { return true; }
            if (NUP_GoodForme2.Value > 0) { return true; }
            if (NUP_GoodMin2.Value > 0) { return true; }
            if (NUP_GoodMax2.Value > 0) { return true; }
            if (CB_Good3.SelectedIndex > 0) { return true; }
            if (NUP_GoodForme3.Value > 0) { return true; }
            if (NUP_GoodMin3.Value > 0) { return true; }
            if (NUP_GoodMax3.Value > 0) { return true; }
            if (CB_Super1.SelectedIndex > 0) { return true; }
            if (NUP_SuperForme1.Value > 0) { return true; }
            if (NUP_SuperMin1.Value > 0) { return true; }
            if (NUP_SuperMax1.Value > 0) { return true; }
            if (CB_Super2.SelectedIndex > 0) { return true; }
            if (NUP_SuperForme2.Value > 0) { return true; }
            if (NUP_SuperMin2.Value > 0) { return true; }
            if (NUP_SuperMax2.Value > 0) { return true; }
            if (CB_Super3.SelectedIndex > 0) { return true; }
            if (NUP_SuperForme3.Value > 0) { return true; }
            if (NUP_SuperMin3.Value > 0) { return true; }
            if (NUP_SuperMax3.Value > 0) { return true; }
            if (CB_HordeA1.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme1.Value > 0) { return true; }
            if (NUP_HordeAMin1.Value > 0) { return true; }
            if (NUP_HordeAMax1.Value > 0) { return true; }
            if (CB_HordeA2.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme2.Value > 0) { return true; }
            if (NUP_HordeAMin2.Value > 0) { return true; }
            if (NUP_HordeAMax2.Value > 0) { return true; }
            if (CB_HordeA3.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme3.Value > 0) { return true; }
            if (NUP_HordeAMin3.Value > 0) { return true; }
            if (NUP_HordeAMax3.Value > 0) { return true; }
            if (CB_HordeA4.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme4.Value > 0) { return true; }
            if (NUP_HordeAMin4.Value > 0) { return true; }
            if (NUP_HordeAMax4.Value > 0) { return true; }
            if (CB_HordeA5.SelectedIndex > 0) { return true; }
            if (NUP_HordeAForme5.Value > 0) { return true; }
            if (NUP_HordeAMin5.Value > 0) { return true; }
            if (NUP_HordeAMax5.Value > 0) { return true; }
            if (CB_HordeB1.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme1.Value > 0) { return true; }
            if (NUP_HordeBMin1.Value > 0) { return true; }
            if (NUP_HordeBMax1.Value > 0) { return true; }
            if (CB_HordeB2.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme2.Value > 0) { return true; }
            if (NUP_HordeBMin2.Value > 0) { return true; }
            if (NUP_HordeBMax2.Value > 0) { return true; }
            if (CB_HordeB3.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme3.Value > 0) { return true; }
            if (NUP_HordeBMin3.Value > 0) { return true; }
            if (NUP_HordeBMax3.Value > 0) { return true; }
            if (CB_HordeB4.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme4.Value > 0) { return true; }
            if (NUP_HordeBMin4.Value > 0) { return true; }
            if (NUP_HordeBMax4.Value > 0) { return true; }
            if (CB_HordeB5.SelectedIndex > 0) { return true; }
            if (NUP_HordeBForme5.Value > 0) { return true; }
            if (NUP_HordeBMin5.Value > 0) { return true; }
            if (NUP_HordeBMax5.Value > 0) { return true; }
            if (CB_HordeC1.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme1.Value > 0) { return true; }
            if (NUP_HordeCMin1.Value > 0) { return true; }
            if (NUP_HordeCMax1.Value > 0) { return true; }
            if (CB_HordeC2.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme2.Value > 0) { return true; }
            if (NUP_HordeCMin2.Value > 0) { return true; }
            if (NUP_HordeCMax2.Value > 0) { return true; }
            if (CB_HordeC3.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme3.Value > 0) { return true; }
            if (NUP_HordeCMin3.Value > 0) { return true; }
            if (NUP_HordeCMax3.Value > 0) { return true; }
            if (CB_HordeC4.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme4.Value > 0) { return true; }
            if (NUP_HordeCMin4.Value > 0) { return true; }
            if (NUP_HordeCMax4.Value > 0) { return true; }
            if (CB_HordeC5.SelectedIndex > 0) { return true; }
            if (NUP_HordeCForme5.Value > 0) { return true; }
            if (NUP_HordeCMin5.Value > 0) { return true; }
            if (NUP_HordeCMax5.Value > 0) { return true; }
            #endregion
            return false;
        }

        private void parse(byte[] ed)
        {
            // Encounter Slot Counts per Encounter Type
            /* OLD XY// 12,12,12,12,12
            // 5,5
            // 3,3,3
            // 5,5,5,*/

            // ORAS
            //12 grass
            //12 tall grass
            //3 Swarm
            //5 surf
            //5 rock smash
            //3 old rod
            //3 good rod
            //3 super rod
            //5 horde 60
            //5 horde 35
            //5 horde 5
            byte[] slot = new Byte[4];
            int[] data = new int[4];
            int offset = 0x0;

            // read data into form
            for (int i = 0; i < max.Length; i++)
            {
                // Fetch Data
                Array.Copy(ed, offset + i * 4, slot, 0, 4);
                data = pslot(slot);

                // Load Data
                spec[i].SelectedIndex = data[0];
                form[i].Value = data[1];
                min[i].Value = data[2];
                max[i].Value = data[3];
            }
        }

        private int[] pslot(byte[] slot) // Parse Slot to Bytes
        {
            int index = BitConverter.ToUInt16(slot, 0) & 0x7FF;
            int form = BitConverter.ToUInt16(slot, 0) >> 11;
            int min = slot[2];
            int max = slot[3];
            int[] data = new int[4];
            data[0] = index;
            data[1] = form;
            data[2] = min;
            data[3] = max;
            return data;
        }
        private string parseslot(byte[] slot)
        {
            int index = BitConverter.ToUInt16(slot, 0) & 0x7FF;
            if (index == 0) return "";
            int form = BitConverter.ToUInt16(slot, 0) >> 11;
            int min = slot[2];
            int max = slot[3];
            string species = specieslist[index];
            if (form > 0) species += "-" + form.ToString();
            return species + ',' + min + ',' + max + ',';
        }

        private void CB_LocationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int f = CB_LocationID.SelectedIndex;
            FileStream InStream = File.OpenRead(filepaths[f]);
            BinaryReader br = new BinaryReader(InStream);
            br.BaseStream.Seek(0x10, SeekOrigin.Begin);
            int offset = br.ReadInt32() + 0xE;
            int ofs2 = br.ReadInt32();
            int length = (int)ofs2 - offset;
            if (length < 0xF6) //no encounters in this map
            {
                ClearData();
                return;
            }
            br.Close();

            byte[] filedata = File.ReadAllBytes(filepaths[f]);

            byte[] encounterdata = new Byte[0xF6];
            Array.Copy(filedata, offset, encounterdata, 0, 0xF6);
            parse(encounterdata);
        }

        private void ClearData()
        {
            for (int i = 0; i < max.Length; i++)
            {
                // Load Data
                spec[i].SelectedIndex = 0;
                form[i].Value = 0;
                min[i].Value = 0;
                max[i].Value = 0;
            }
        }

        private byte[] MakeSlotData(int species, int form, int min, int max)
        {
            byte[] data = new byte[4];
            Array.Copy(BitConverter.GetBytes(Convert.ToUInt16((Convert.ToUInt16(form) << 11) + Convert.ToUInt16(species))), 0, data, 0, 2);
            data[2] = (byte)min;
            data[3] = (byte)max;
            return data;
        }

        private byte[] MakeEncounterData()
        {
            byte[] ed = new byte[0x102];
            byte[] data;
            int offset = 0x0;
            for (int i = 0; i < max.Length; i++)
            {
                data = MakeSlotData(spec[i].SelectedIndex, (int)form[i].Value, (int)min[i].Value, (int)max[i].Value);
                Array.Copy(data, 0, ed, offset + i * 4, 4);
            }
            return ed;
        }

        private byte[] ConcatArrays(byte[] b1, byte[] b2)
        {
            byte[] concat = new byte[b1.Length + b2.Length];
            Array.Copy(b1, 0, concat, 0, b1.Length);
            Array.Copy(b2, 0, concat, b1.Length, b2.Length);
            return concat;
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            int f = CB_LocationID.SelectedIndex;
            string filepath = filepaths[f];
            if (needsInsertion(f))
            {
                //To be implemented, eventually. 
                //Spoiler: I am actually probably not going to bother.
                //Basically, just don't add encounters to a map that doesn't have any, and don't take away all encounters from a map that does have them.
            }
            else
            {
                FileStream InStream = File.OpenRead(filepaths[f]);
                BinaryReader br = new BinaryReader(InStream);
                br.BaseStream.Seek(0x10, SeekOrigin.Begin);
                int offset = br.ReadInt32() + 0xe;
                int length = (int)br.BaseStream.Length - offset;
                br.Close();
                byte[] filedata = File.ReadAllBytes(filepaths[f]);
                byte[] preoffset = new byte[] { };
                if (offset < filedata.Length)
                {
                    preoffset = new byte[offset];
                    Array.Copy(filedata, preoffset, offset);
                }
                else
                {
                    preoffset = new byte[filedata.Length];
                    Array.Copy(filedata, preoffset, filedata.Length);
                    //overwrite offset so the game actually looks at the data
                    Array.Copy(BitConverter.GetBytes(Convert.ToUInt32(filedata.Length)), 0, preoffset, 0x10, 4);
                }
                byte[] encdata = new byte[] { };
                if (hasData()) { encdata = MakeEncounterData(); }
                byte[] newdata = ConcatArrays(preoffset, encdata);
                File.WriteAllBytes(filepath, newdata);
                //Also write to 537.EN (decStorage)
                int ENOfs = BitConverter.ToInt32(decStorage, (f + 1) * 4) + 0xE;
                encdata = MakeEncounterData();
                Array.Copy(encdata, 0x0, decStorage, ENOfs, 0xF4); //copy encounter tables to EN 2pack storage
                File.WriteAllBytes(this.encdatapaths[1], decStorage);
            }
        }

        private void PreloadTabs()
        {
            for (int i = 0; i < this.TabControl_EncounterData.TabPages.Count; i++)
            {
                this.TabControl_EncounterData.TabPages[i].Show();
            }
            this.TabControl_EncounterData.TabPages[0].Show();
        }

        private void TabPage_Land_Click(object sender, EventArgs e)
        {

        }

        private string GetEncDataString()
        {
            string toret = "======\r\n";
            toret += "Map " + CB_LocationID.Text + "\r\n";
            toret += "======\r\n";
            if (hasData())
            {
                toret += "Grass: " + CB_Grass1.Text + "(Level " + NUP_GrassMin1.Text + ")," + CB_Grass2.Text + "(Level " + NUP_GrassMin2.Text + ")," + CB_Grass3.Text + "(Level " + NUP_GrassMin3.Text + ")," + CB_Grass4.Text + "(Level " + NUP_GrassMin4.Text + ")," + CB_Grass5.Text + "(Level " + NUP_GrassMin5.Text + ")," + CB_Grass6.Text + "(Level " + NUP_GrassMin6.Text + ")," + CB_Grass7.Text + "(Level " + NUP_GrassMin7.Text + ")," + CB_Grass8.Text + "(Level " + NUP_GrassMin8.Text + ")," + CB_Grass9.Text + "(Level " + NUP_GrassMin9.Text + ")," + CB_Grass10.Text + "(Level " + NUP_GrassMin10.Text + ")," + CB_Grass11.Text + "(Level " + NUP_GrassMin11.Text + ")," + CB_Grass12.Text + "(Level " + NUP_GrassMin12.Text + ")\r\n";
                toret += "TallGrass: " + CB_TallGrass1.Text + "(Level " + NUP_TallGrassMin1.Text + ")," + CB_TallGrass2.Text + "(Level " + NUP_TallGrassMin2.Text + ")," + CB_TallGrass3.Text + "(Level " + NUP_TallGrassMin3.Text + ")," + CB_TallGrass4.Text + "(Level " + NUP_TallGrassMin4.Text + ")," + CB_TallGrass5.Text + "(Level " + NUP_TallGrassMin5.Text + ")," + CB_TallGrass6.Text + "(Level " + NUP_TallGrassMin6.Text + ")," + CB_TallGrass7.Text + "(Level " + NUP_TallGrassMin7.Text + ")," + CB_TallGrass8.Text + "(Level " + NUP_TallGrassMin8.Text + ")," + CB_TallGrass9.Text + "(Level " + NUP_TallGrassMin9.Text + ")," + CB_TallGrass10.Text + "(Level " + NUP_TallGrassMin10.Text + ")," + CB_TallGrass11.Text + "(Level " + NUP_TallGrassMin11.Text + ")," + CB_TallGrass12.Text + "(Level " + NUP_TallGrassMin12.Text + ")\r\n";
                toret += "RockSmash: " + CB_RockSmash1.Text + "(Level " + NUP_RockSmashMin1.Text + ")," + CB_RockSmash2.Text + "(Level " + NUP_RockSmashMin2.Text + ")," + CB_RockSmash3.Text + "(Level " + NUP_RockSmashMin3.Text + ")," + CB_RockSmash4.Text + "(Level " + NUP_RockSmashMin4.Text + ")," + CB_RockSmash5.Text + "(Level " + NUP_RockSmashMin5.Text + ")\r\n";
                toret += "Swarm: " + CB_Swarm1.Text + "(Level " + NUP_SwarmMin1.Text + ")," + CB_Swarm2.Text + "(Level " + NUP_SwarmMin2.Text + ")," + CB_Swarm3.Text + "(Level " + NUP_SwarmMin3.Text + ")\r\n";
                toret += "Old: " + CB_Old1.Text + "(Level " + NUP_OldMin1.Text + ")," + CB_Old2.Text + "(Level " + NUP_OldMin2.Text + ")," + CB_Old3.Text + "(Level " + NUP_OldMin3.Text + ")\r\n";
                toret += "Good: " + CB_Good1.Text + "(Level " + NUP_GoodMin1.Text + ")," + CB_Good2.Text + "(Level " + NUP_GoodMin2.Text + ")," + CB_Good3.Text + "(Level " + NUP_GoodMin3.Text + ")\r\n";
                toret += "Super: " + CB_Super1.Text + "(Level " + NUP_SuperMin1.Text + ")," + CB_Super2.Text + "(Level " + NUP_SuperMin2.Text + ")," + CB_Super3.Text + "(Level " + NUP_SuperMin3.Text + ")\r\n";
                toret += "Surf: " + CB_Surf1.Text + "(Level " + NUP_SurfMin1.Text + ")," + CB_Surf2.Text + "(Level " + NUP_SurfMin2.Text + ")," + CB_Surf3.Text + "(Level " + NUP_SurfMin3.Text + ")," + CB_Surf4.Text + "(Level " + NUP_SurfMin4.Text + ")," + CB_Surf5.Text + "(Level " + NUP_SurfMin5.Text + ")\r\n";
                toret += "HordeA: " + CB_HordeA1.Text + "(Level " + NUP_HordeAMin1.Text + ")," + CB_HordeA2.Text + "(Level " + NUP_HordeAMin2.Text + ")," + CB_HordeA3.Text + "(Level " + NUP_HordeAMin3.Text + ")," + CB_HordeA4.Text + "(Level " + NUP_HordeAMin4.Text + ")," + CB_HordeA5.Text + "(Level " + NUP_HordeAMin5.Text + ")\r\n";
                toret += "HordeB: " + CB_HordeB1.Text + "(Level " + NUP_HordeBMin1.Text + ")," + CB_HordeB2.Text + "(Level " + NUP_HordeBMin2.Text + ")," + CB_HordeB3.Text + "(Level " + NUP_HordeBMin3.Text + ")," + CB_HordeB4.Text + "(Level " + NUP_HordeBMin4.Text + ")," + CB_HordeB5.Text + "(Level " + NUP_HordeBMin5.Text + ")\r\n";
                toret += "HordeC: " + CB_HordeC1.Text + "(Level " + NUP_HordeCMin1.Text + ")," + CB_HordeC2.Text + "(Level " + NUP_HordeCMin2.Text + ")," + CB_HordeC3.Text + "(Level " + NUP_HordeCMin3.Text + ")," + CB_HordeC4.Text + "(Level " + NUP_HordeCMin4.Text + ")," + CB_HordeC5.Text + "(Level " + NUP_HordeCMin5.Text + ")\r\n";
            }
            else
                toret += "No encounters found.\r\n\r\n";
            return toret;
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            string toret = "";
            for (int i = 0; i < 535; i++) //hardcoded map count. Yes, it's bad. No, I don't really care.
            {
                CB_LocationID.SelectedIndex = i;
                string tdata = GetEncDataString();
                toret += tdata;
            }
            SaveFileDialog savetxt = new SaveFileDialog();
            savetxt.FileName = "Encounter Slots";
            savetxt.Filter = "Text File|*.txt";
            if (savetxt.ShowDialog() == DialogResult.OK)
            {
                string path = savetxt.FileName;
                File.WriteAllText(path, toret);
            }
        }

        private void dragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            openQuick(files[0]);
        }
        private void dragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}
