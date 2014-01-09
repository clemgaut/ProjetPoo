﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace UITestProject
{
    using System;
    using System.Threading;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public partial class UIMap
    {
        
        /// <summary>
        /// StartGaulNain - Use 'StartGaulNainParams' to pass parameters into this method.
        /// </summary>
        public void StartGaulNain()
        {
            #region Variable Declarations
            WpfButton uINouvellePartieButton = this.UIBienvenuesurSmallWorWindow.UINouvellePartieButton;
            WpfComboBox uIComboBoxNationPlayerComboBox = this.UIBienvenuesurSmallWorWindow.UIComboBoxNationPlayerComboBox;
            WpfComboBox uIComboBoxNationPlayerComboBox1 = this.UIBienvenuesurSmallWorWindow.UIComboBoxNationPlayerComboBox1;
            WpfButton uILancerlapartieButton = this.UIBienvenuesurSmallWorWindow.UILancerlapartieButton;
            #endregion

            // Last mouse action was not recorded.

            // Click 'Nouvelle Partie' button
            Mouse.Click(uINouvellePartieButton, new Point(89, 8));

            // Last mouse action was not recorded.

            // Select 'Gaulois' in 'ComboBoxNationPlayer1' combo box
            uIComboBoxNationPlayerComboBox.SelectedItem = this.StartGaulNainParams.UIComboBoxNationPlayerComboBoxSelectedItem;

            // Select 'Nains' in 'ComboBoxNationPlayer2' combo box
            uIComboBoxNationPlayerComboBox1.SelectedItem = this.StartGaulNainParams.UIComboBoxNationPlayerComboBox1SelectedItem;

            // Click 'Lancer la partie' button
            Mouse.Click(uILancerlapartieButton, new Point(68, 15));
        }
        
        /// <summary>
        /// AssertNation1 - Use 'AssertNation1ExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertNation1()
        {
            #region Variable Declarations
            WpfText uIJoueur1GAULText1 = this.UISmallWorldWindow.UIJoueur1GAULText.UIJoueur1GAULText1;
            #endregion

            // Verify that the 'DisplayText' property of 'Joueur 1 [GAUL]' label contains 'GAUL'
            StringAssert.Contains(uIJoueur1GAULText1.DisplayText, this.AssertNation1ExpectedValues.UIJoueur1GAULText1DisplayText, "Wrong nation");
        }
        
        /// <summary>
        /// AssertNation2 - Use 'AssertNation2ExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertNation2()
        {
            #region Variable Declarations
            WpfText uIJoueur2NAINText1 = this.UISmallWorldWindow.UIJoueur2NAINText.UIJoueur2NAINText1;
            #endregion

            // Verify that the 'DisplayText' property of 'Joueur 2 [NAIN]' label contains 'NAIN'
            StringAssert.Contains(uIJoueur2NAINText1.DisplayText, this.AssertNation2ExpectedValues.UIJoueur2NAINText1DisplayText, "Wrong nation");
        }
        
        /// <summary>
        /// AssertUnits - Use 'AssertUnitsExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertUnits()
        {
            #region Variable Declarations
            WpfText uIUnitéesrestantes8Text1 = this.UISmallWorldWindow.UIUnitéesrestantes8Text.UIUnitéesrestantes8Text1;
            #endregion

            // Verify that the 'DisplayText' property of 'Unitées restantes : 8' label contains '8'
            StringAssert.Contains(uIUnitéesrestantes8Text1.DisplayText, this.AssertUnitsExpectedValues.UIUnitéesrestantes8Text1DisplayText);
        }
        
        /// <summary>
        /// QuitGame
        /// </summary>
        public void QuitGame()
        {
            #region Variable Declarations
            WpfButton uIMenuButton = this.UISmallWorldWindow.UIMenuButton;
            WpfButton uIQuitterButton = this.UIBienvenuesurSmallWorWindow.UIQuitterButton;
            #endregion

            // Click 'Menu' button
            Mouse.Click(uIMenuButton, new Point(42, 12));

            // Last mouse action was not recorded.
            Thread.Sleep(100);
            // Click 'Quitter' button
            Mouse.Click(uIQuitterButton, new Point(87, 19));
        }
        
        #region Properties
        public virtual StartGaulNainParams StartGaulNainParams
        {
            get
            {
                if ((this.mStartGaulNainParams == null))
                {
                    this.mStartGaulNainParams = new StartGaulNainParams();
                }
                return this.mStartGaulNainParams;
            }
        }
        
        public virtual AssertNation1ExpectedValues AssertNation1ExpectedValues
        {
            get
            {
                if ((this.mAssertNation1ExpectedValues == null))
                {
                    this.mAssertNation1ExpectedValues = new AssertNation1ExpectedValues();
                }
                return this.mAssertNation1ExpectedValues;
            }
        }
        
        public virtual AssertNation2ExpectedValues AssertNation2ExpectedValues
        {
            get
            {
                if ((this.mAssertNation2ExpectedValues == null))
                {
                    this.mAssertNation2ExpectedValues = new AssertNation2ExpectedValues();
                }
                return this.mAssertNation2ExpectedValues;
            }
        }
        
        public virtual AssertUnitsExpectedValues AssertUnitsExpectedValues
        {
            get
            {
                if ((this.mAssertUnitsExpectedValues == null))
                {
                    this.mAssertUnitsExpectedValues = new AssertUnitsExpectedValues();
                }
                return this.mAssertUnitsExpectedValues;
            }
        }
        
        public UIBienvenuesurSmallWorWindow UIBienvenuesurSmallWorWindow
        {
            get
            {
                if ((this.mUIBienvenuesurSmallWorWindow == null))
                {
                    this.mUIBienvenuesurSmallWorWindow = new UIBienvenuesurSmallWorWindow();
                }
                return this.mUIBienvenuesurSmallWorWindow;
            }
        }
        
        public UISmallWorldWindow UISmallWorldWindow
        {
            get
            {
                if ((this.mUISmallWorldWindow == null))
                {
                    this.mUISmallWorldWindow = new UISmallWorldWindow();
                }
                return this.mUISmallWorldWindow;
            }
        }
        #endregion
        
        #region Fields
        private StartGaulNainParams mStartGaulNainParams;
        
        private AssertNation1ExpectedValues mAssertNation1ExpectedValues;
        
        private AssertNation2ExpectedValues mAssertNation2ExpectedValues;
        
        private AssertUnitsExpectedValues mAssertUnitsExpectedValues;
        
        private UIBienvenuesurSmallWorWindow mUIBienvenuesurSmallWorWindow;
        
        private UISmallWorldWindow mUISmallWorldWindow;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'StartGaulNain'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class StartGaulNainParams
    {
        
        #region Fields
        /// <summary>
        /// Select 'Gaulois' in 'ComboBoxNationPlayer1' combo box
        /// </summary>
        public string UIComboBoxNationPlayerComboBoxSelectedItem = "Gaulois";
        
        /// <summary>
        /// Select 'Nains' in 'ComboBoxNationPlayer2' combo box
        /// </summary>
        public string UIComboBoxNationPlayerComboBox1SelectedItem = "Nains";
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'AssertNation1'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class AssertNation1ExpectedValues
    {
        
        #region Fields
        /// <summary>
        /// Verify that the 'DisplayText' property of 'Joueur 1 [GAUL]' label contains 'GAUL'
        /// </summary>
        public string UIJoueur1GAULText1DisplayText = "GAUL";
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'AssertNation2'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class AssertNation2ExpectedValues
    {
        
        #region Fields
        /// <summary>
        /// Verify that the 'DisplayText' property of 'Joueur 2 [NAIN]' label contains 'NAIN'
        /// </summary>
        public string UIJoueur2NAINText1DisplayText = "NAIN";
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'AssertUnits'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class AssertUnitsExpectedValues
    {
        
        #region Fields
        /// <summary>
        /// Verify that the 'DisplayText' property of 'Unitées restantes : 8' label contains '8'
        /// </summary>
        public string UIUnitéesrestantes8Text1DisplayText = "8";
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class UIBienvenuesurSmallWorWindow : WpfWindow
    {
        
        public UIBienvenuesurSmallWorWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "Bienvenue sur SmallWorld";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Bienvenue sur SmallWorld");
            #endregion
        }
        
        #region Properties
        public WpfButton UINouvellePartieButton
        {
            get
            {
                if ((this.mUINouvellePartieButton == null))
                {
                    this.mUINouvellePartieButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUINouvellePartieButton.SearchProperties[WpfButton.PropertyNames.Name] = "Nouvelle Partie";
                    this.mUINouvellePartieButton.WindowTitles.Add("Bienvenue sur SmallWorld");
                    #endregion
                }
                return this.mUINouvellePartieButton;
            }
        }
        
        public WpfComboBox UIComboBoxNationPlayerComboBox
        {
            get
            {
                if ((this.mUIComboBoxNationPlayerComboBox == null))
                {
                    this.mUIComboBoxNationPlayerComboBox = new WpfComboBox(this);
                    #region Search Criteria
                    this.mUIComboBoxNationPlayerComboBox.SearchProperties[WpfComboBox.PropertyNames.AutomationId] = "ComboBoxNationPlayer1";
                    this.mUIComboBoxNationPlayerComboBox.WindowTitles.Add("Bienvenue sur SmallWorld");
                    #endregion
                }
                return this.mUIComboBoxNationPlayerComboBox;
            }
        }
        
        public WpfComboBox UIComboBoxNationPlayerComboBox1
        {
            get
            {
                if ((this.mUIComboBoxNationPlayerComboBox1 == null))
                {
                    this.mUIComboBoxNationPlayerComboBox1 = new WpfComboBox(this);
                    #region Search Criteria
                    this.mUIComboBoxNationPlayerComboBox1.SearchProperties[WpfComboBox.PropertyNames.AutomationId] = "ComboBoxNationPlayer2";
                    this.mUIComboBoxNationPlayerComboBox1.WindowTitles.Add("Bienvenue sur SmallWorld");
                    #endregion
                }
                return this.mUIComboBoxNationPlayerComboBox1;
            }
        }
        
        public WpfButton UILancerlapartieButton
        {
            get
            {
                if ((this.mUILancerlapartieButton == null))
                {
                    this.mUILancerlapartieButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUILancerlapartieButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "StartUpButton";
                    this.mUILancerlapartieButton.WindowTitles.Add("Bienvenue sur SmallWorld");
                    #endregion
                }
                return this.mUILancerlapartieButton;
            }
        }
        
        public WpfButton UIQuitterButton
        {
            get
            {
                if ((this.mUIQuitterButton == null))
                {
                    this.mUIQuitterButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIQuitterButton.SearchProperties[WpfButton.PropertyNames.Name] = "Quitter";
                    this.mUIQuitterButton.WindowTitles.Add("Bienvenue sur SmallWorld");
                    #endregion
                }
                return this.mUIQuitterButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfButton mUINouvellePartieButton;
        
        private WpfComboBox mUIComboBoxNationPlayerComboBox;
        
        private WpfComboBox mUIComboBoxNationPlayerComboBox1;
        
        private WpfButton mUILancerlapartieButton;
        
        private WpfButton mUIQuitterButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class UISmallWorldWindow : WpfWindow
    {
        
        public UISmallWorldWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "SmallWorld";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("SmallWorld");
            #endregion
        }
        
        #region Properties
        public UIJoueur1GAULText UIJoueur1GAULText
        {
            get
            {
                if ((this.mUIJoueur1GAULText == null))
                {
                    this.mUIJoueur1GAULText = new UIJoueur1GAULText(this);
                }
                return this.mUIJoueur1GAULText;
            }
        }
        
        public UIJoueur2NAINText UIJoueur2NAINText
        {
            get
            {
                if ((this.mUIJoueur2NAINText == null))
                {
                    this.mUIJoueur2NAINText = new UIJoueur2NAINText(this);
                }
                return this.mUIJoueur2NAINText;
            }
        }
        
        public UIUnitéesrestantes8Text UIUnitéesrestantes8Text
        {
            get
            {
                if ((this.mUIUnitéesrestantes8Text == null))
                {
                    this.mUIUnitéesrestantes8Text = new UIUnitéesrestantes8Text(this);
                }
                return this.mUIUnitéesrestantes8Text;
            }
        }
        
        public WpfButton UIMenuButton
        {
            get
            {
                if ((this.mUIMenuButton == null))
                {
                    this.mUIMenuButton = new WpfButton(this);
                    #region Search Criteria
                    this.mUIMenuButton.SearchProperties[WpfButton.PropertyNames.Name] = "Menu";
                    this.mUIMenuButton.WindowTitles.Add("SmallWorld");
                    #endregion
                }
                return this.mUIMenuButton;
            }
        }
        #endregion
        
        #region Fields
        private UIJoueur1GAULText mUIJoueur1GAULText;
        
        private UIJoueur2NAINText mUIJoueur2NAINText;
        
        private UIUnitéesrestantes8Text mUIUnitéesrestantes8Text;
        
        private WpfButton mUIMenuButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class UIJoueur1GAULText : WpfText
    {
        
        public UIJoueur1GAULText(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.AutomationId] = "Nation1Label";
            this.WindowTitles.Add("SmallWorld");
            #endregion
        }
        
        #region Properties
        public WpfText UIJoueur1GAULText1
        {
            get
            {
                if ((this.mUIJoueur1GAULText1 == null))
                {
                    this.mUIJoueur1GAULText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIJoueur1GAULText1.SearchProperties[WpfText.PropertyNames.Name] = "Joueur 1 [GAUL]";
                    this.mUIJoueur1GAULText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIJoueur1GAULText1.WindowTitles.Add("SmallWorld");
                    #endregion
                }
                return this.mUIJoueur1GAULText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIJoueur1GAULText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class UIJoueur2NAINText : WpfText
    {
        
        public UIJoueur2NAINText(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.AutomationId] = "Nation2Label";
            this.WindowTitles.Add("SmallWorld");
            #endregion
        }
        
        #region Properties
        public WpfText UIJoueur2NAINText1
        {
            get
            {
                if ((this.mUIJoueur2NAINText1 == null))
                {
                    this.mUIJoueur2NAINText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIJoueur2NAINText1.SearchProperties[WpfText.PropertyNames.Name] = "Joueur 2 [NAIN]";
                    this.mUIJoueur2NAINText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIJoueur2NAINText1.WindowTitles.Add("SmallWorld");
                    #endregion
                }
                return this.mUIJoueur2NAINText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIJoueur2NAINText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class UIUnitéesrestantes8Text : WpfText
    {
        
        public UIUnitéesrestantes8Text(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.AutomationId] = "Units1Label";
            this.WindowTitles.Add("SmallWorld");
            #endregion
        }
        
        #region Properties
        public WpfText UIUnitéesrestantes8Text1
        {
            get
            {
                if ((this.mUIUnitéesrestantes8Text1 == null))
                {
                    this.mUIUnitéesrestantes8Text1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIUnitéesrestantes8Text1.SearchProperties[WpfText.PropertyNames.Name] = "Unitées restantes : 8";
                    this.mUIUnitéesrestantes8Text1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIUnitéesrestantes8Text1.WindowTitles.Add("SmallWorld");
                    #endregion
                }
                return this.mUIUnitéesrestantes8Text1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIUnitéesrestantes8Text1;
        #endregion
    }
}
