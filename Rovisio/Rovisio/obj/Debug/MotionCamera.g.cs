<<<<<<< HEAD
﻿#pragma checksum "C:\Users\V\Documents\GitHub\pds2013\Rovisio\Rovisio\MotionCamera.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D401176D6C539750B7D18A27D7F17C5B"
=======
<<<<<<< HEAD
﻿#pragma checksum "C:\Users\antti\Documents\GitHub\PDS2013\Rovisio\Rovisio\MotionCamera.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D3117FEB42088250811E5969F42B6DB9"
=======
﻿#pragma checksum "C:\Users\lurkki\Documents\GitHub\pds2013\Rovisio\Rovisio\MotionCamera.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D3117FEB42088250811E5969F42B6DB9"
>>>>>>> origin/mvi_server
>>>>>>> 825c4f733c9cdb5dbed44a93e21863ddbc6c69fb
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Rovisio {
    
    
    public partial class MotionCamera : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock statusTextBlock;
        
        internal System.Windows.Controls.TextBlock timeBetweenUpdatesTextBlock;
        
        internal System.Windows.Controls.TextBlock xTextBlock;
        
        internal System.Windows.Controls.TextBlock yTextBlock;
        
        internal System.Windows.Controls.TextBlock zTextBlock;
        
        internal System.Windows.Controls.TextBlock pitchBlock;
        
        internal System.Windows.Controls.TextBlock rollBlock;
        
        internal System.Windows.Controls.Image image1;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Rovisio;component/MotionCamera.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.statusTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("statusTextBlock")));
            this.timeBetweenUpdatesTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("timeBetweenUpdatesTextBlock")));
            this.xTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("xTextBlock")));
            this.yTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("yTextBlock")));
            this.zTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("zTextBlock")));
            this.pitchBlock = ((System.Windows.Controls.TextBlock)(this.FindName("pitchBlock")));
            this.rollBlock = ((System.Windows.Controls.TextBlock)(this.FindName("rollBlock")));
            this.image1 = ((System.Windows.Controls.Image)(this.FindName("image1")));
        }
    }
}
