using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MetroFramework.Controls;

namespace Citrullia.UserControls
{
    /// <summary>The modification parameter control in Analysis.</summary>
    internal partial class AnalModUC : UserControl
    {
        /// <summary>
        /// Create a new instance of <see cref="AnalModUC"/>.
        /// </summary>
        internal AnalModUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the form.
        /// </summary>
        private void AnalModUC_Load(object sender, EventArgs e)
        {
            UpdateListViewModifications();
        }
        
        /// <summary>
        /// Change weather X!Tandem should use average or monoisotopic masses.
        /// </summary>
        private void MetroToggleAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggleAverage.Checked == true)
            {
                metroToggleMonoIso.Checked = false;
            }
            else
            {
                metroToggleMonoIso.Checked = true;
            }
            UpdateListViewModifications();
        }

        /// <summary>
        /// Update the modification ListView.
        /// </summary>
        private void UpdateListViewModifications()
        {
            // Get the modification files
            string VModMono = External.CitrulliaSettings.VariableModificationMonoMassFile;
            string VModAvg = External.CitrulliaSettings.VariableModificatioAvgMassFile;
            string FMod = External.CitrulliaSettings.FixedModificationFile;

            //Variable Modifications
            UpdateModifcationListView(metroListViewVModi, VModMono, VModAvg);
            // Fixed modifications
            UpdateModifcationListView(metroListViewFModi, FMod, FMod);
            // Refinment: Variable modifications
            UpdateModifcationListView(metroListViewRVModi, VModMono, VModAvg);
        }

        /// <summary>
        /// Update the list view.
        /// </summary>
        /// <param name="list">The list view to be updated.</param>
        /// <param name="modMono">The file that contains the modifications (Monoisotopic mass).</param>
        /// <param name="modAvg">The file that contains the modifications (Average mass).</param>
        private void UpdateModifcationListView(MetroListView list, string modMono, string modAvg)
        {
            list.BeginUpdate();
            list.Items.Clear();
            list.Columns.Clear();
            list.View = View.Details;

            list.Columns.Add("Name");
            list.Columns.Add("Residue(s)");
            list.Columns.Add("Mass Change");

            // Check if should read monoisotopic or average masses
            if (metroToggleMonoIso.Checked == true)
            {
                ReadModifications(modMono, list);
            }
            else
            {
                ReadModifications(modAvg, list);
            }

            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            list.EndUpdate();
        }

        /// <summary>
        /// Read and add the modifications to the the list view.
        /// </summary>
        /// <param name="filePath">The filepath of the modifications to be added.</param>
        /// <param name="metroListView">The list view they should be added to.</param>
        private void ReadModifications(string filePath, ListView metroListView)
        {
            // Get the modification lines in the file.
            string[] modificationList = File.ReadAllLines(filePath);
            // Loop through all of the modifications and add them to the list view
            foreach (string line in modificationList)
            {
                ListViewItem lvi;
                lvi = new ListViewItem(line.Split(' ').ToArray());
                metroListView.Items.Add(lvi);
            }
        }

        internal static List<string> variableModifications = new List<string>();
        /// <summary>
        /// Change a variable modification.
        /// </summary>
        private void MetroListViewVModi_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // Check if the modification is checked (activated)
            if (e.Item.Checked == true)
            {
                // If checked, add the modification to the list.
                variableModifications = AddModifications(e.Item, variableModifications);
                Console.WriteLine("VMod: " + variableModifications.Count());
            }
            else
            {
                // If unchecked, removed the modification to the list.
                variableModifications = RemoveModifications(e.Item, variableModifications);
                Console.WriteLine("VMod: " + variableModifications.Count());
            }
        }

        internal static List<string> fixedModifications = new List<string>();
        /// <summary>
        /// Change a fixed modification.
        /// </summary>
        private void MetroListViewFModi_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // Check if the modification is checked (activated)
            if (e.Item.Checked == true)
            {
                // If checked, add the modification to the list.
                fixedModifications = AddModifications(e.Item, fixedModifications);
                Console.WriteLine("FMod: " + fixedModifications.Count());
            }
            else
            {
                // If unchecked, removed the modification to the list.
                fixedModifications = RemoveModifications(e.Item, fixedModifications);
                Console.WriteLine("FMod: " + fixedModifications.Count());
            }
        }

        internal static List<string> variableRefinmentModifications = new List<string>();

        /// <summary>
        /// Change a variable modification (Refienment).
        /// </summary>
        private void MetroListViewRVModi_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // Check if the modification is checked (activated)
            if (e.Item.Checked == true)
            {
                // If checked, add the modification to the list.
                variableRefinmentModifications = AddModifications(e.Item, variableRefinmentModifications);
                Console.WriteLine("RVMod: " + variableRefinmentModifications.Count());
            }
            else
            {
                // If unchecked, removed the modification to the list.s
                variableRefinmentModifications = RemoveModifications(e.Item, variableRefinmentModifications);
                Console.WriteLine("RVMod: " + variableRefinmentModifications.Count());
            }
        }

        /// <summary>
        /// Add a modification to the modification list.
        /// </summary>
        /// <param name="listItem">The listview item to be added.</param>
        /// <param name="modifications">The current list of modifications.</param>
        /// <returns>The new list of modifications.</returns>
        private List<string> AddModifications(ListViewItem listItem, List<string> modifications)
        {
            // Get the residues modified
            string residues = listItem.SubItems[1].Text;
            // Convert the residues to an char array.
            char[] singleRes = residues.ToCharArray();
            // Chars to be removed
            char remove1 = '[';
            char remove2 = ']';
            // Remove the chars to be removed and create a list.
            singleRes = singleRes.Where(val => val != remove1 & val != remove2).ToArray();
            // Get the mass change
            string massChange = listItem.SubItems[2].Text;

            // Loop through the list of residue modifications and add them to the modification list.
            foreach (char res in singleRes)
            {
                modifications.Add(string.Format("{0}@{1}", massChange, res));
            }
            // Return the new modification list.
            return modifications;
        }

        /// <summary>
        /// Remmove a modification from the modification list.
        /// </summary>
        /// <param name="listItem">The listview item to be removed.</param>
        /// <param name="modifications">The current list of modifications.</param>
        /// <returns>The new list of modifications.</returns>
        private List<string> RemoveModifications(ListViewItem listItem, List<string> modifications)
        {
            // Get the residues modified
            string residues = listItem.SubItems[1].Text;
            // Convert the residues to an char array.
            char[] singleRes = residues.ToCharArray();
            // Chars to be removed
            char remove1 = '[';
            char remove2 = ']';
            // Remove the chars to be removed and create a list.
            singleRes = singleRes.Where(val => val != remove1 & val != remove2).ToArray();
            // Get the mass change
            string massChange = listItem.SubItems[2].Text;

            // Loop through the list of residue modifications and remove them from the modification list.
            foreach (char res in singleRes)
            {
                string fdd = string.Format("{0}@{1}", massChange, res);
                modifications.Remove(fdd);
            }
            return modifications;
        }

        /// <summary>
        /// Create the modification output.
        /// </summary>
        /// <param name="modifications">The list of modifications.</param>
        /// <returns>The new modification string.</returns>
        internal static string ModificationsOutput(List<string> modifications)
        {
            // Create an empty stringBuilder
            StringBuilder modStringBuilder = new StringBuilder();

            // Check if any modifications.
            if (modifications.Any())
            {
                // Loop through the list of modifications.               
                foreach (string mod in modifications)
                {
                    modStringBuilder.AppendFormat("{0},", mod);
                }

                // Get the string from StringBuilder and remove the last comma in the string
                return modStringBuilder.ToString().Remove(modStringBuilder.Length - 1);
            }

            // Return the new modification string
            return "";


        }
    }
}
