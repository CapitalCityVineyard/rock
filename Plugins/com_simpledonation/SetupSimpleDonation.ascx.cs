using System;
using System.ComponentModel;
using com.SimpleDonation.API;
using Rock;
using Rock.Attribute;
using Rock.Web.UI.Controls;

namespace Plugins.com_simpledonation
{
    /// <summary>
    /// Template block for developers to use to start a new block.
    /// </summary>
    [DisplayName( "Setup Simple Donation" )]
    [Category( "Simple Donation" )]
    [Description( "Configure your Simple Donation integration" )]
    public partial class SimpleDonationSetup : Rock.Web.UI.RockBlock
    {
        #region Fields

        // used for private variables

        #endregion

        #region Properties

        // used for public / protected properties

        #endregion

        #region Base Control Methods

        //  overrides of the base RockBlock methods (i.e. OnInit, OnLoad)

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            // this event gets fired after block settings are updated. it's nice to repaint the screen if these settings would alter it
            this.BlockUpdated += Block_BlockUpdated;
            this.AddConfigurationUpdateTrigger( upnlContent );
            nbSimpleDonation.Visible = false;
            divInstructions.Visible = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !Page.IsPostBack )
            {
                // added for your convenience
            }
        }

        #endregion

        #region Events

        // handlers called by the controls on your block

        /// <summary>
        /// Handles the BlockUpdated event of the control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Block_BlockUpdated( object sender, EventArgs e )
        {

        }

        #endregion

        #region Methods

        // helper functional methods (like BindGrid(), etc.)

        #endregion

        protected void lbConfigure_Click(object sender, EventArgs e)
        {
            lbConfigure.Enabled = false;
            divInstructions.Visible = false;
            if (SimpleDonationApi.Signup(tbApiKey.Text.Trim()))
            {

                nbSimpleDonation.Title = "Success! Simple Donation is ready!";
                nbSimpleDonation.NotificationBoxType = NotificationBoxType.Success;
                nbSimpleDonation.Visible = true;
                lbConfigure.Visible = false;
                tbApiKey.Visible = false;
            }
            else
            {
                nbSimpleDonation.Title = "Oops! Looks like something went wrong. Have you double checked your API key? \n You can find your Simple Donation API Key by logging into your Simple Donation admin interface and looking under the settings tab";
                nbSimpleDonation.NotificationBoxType = NotificationBoxType.Danger;
                nbSimpleDonation.Visible = true;
            }
            lbConfigure.Enabled = true;
        }
    }
}