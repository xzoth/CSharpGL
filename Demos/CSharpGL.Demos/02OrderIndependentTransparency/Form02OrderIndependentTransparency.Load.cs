﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form02OrderIndependentTransparency : Form
    {
        private Form03OrderDependentTransparency form03;


        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                IBufferable bufferable = new Teapot();
                var OITRenderer = new OrderIndependentTransparencyRenderer(
                    bufferable, Teapot.strPosition, Teapot.strNormal);
                OITRenderer.Name = "OIT Renderer";
                OITRenderer.Initialize();

                this.OITRenderer = OITRenderer;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.OITRenderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }

            this.form03 = new Form03OrderDependentTransparency(this);
            this.form03.Show();
        }
    }
}
