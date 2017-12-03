﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Platform.WinForms
{
	public class PageRenderer : VisualElementRenderer<Page, System.Windows.Forms.Panel>
	{
		public PageRenderer()
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new System.Windows.Forms.Panel());
				}
			}
		}
	}
}