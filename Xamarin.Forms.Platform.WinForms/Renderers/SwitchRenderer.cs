﻿using System;
using System.ComponentModel;

namespace Xamarin.Forms.Platform.WinForms
{
	public class SwitchRenderer : ViewRenderer<Switch, System.Windows.Forms.CheckBox>
	{
		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				Control.CheckedChanged += Platform.BlockRenter((s, e2) => Element.IsToggled = Control.Checked);
				UpdateToggle();
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Switch.IsToggledProperty.PropertyName)
			{
				UpdateToggle();
			}
			base.OnElementPropertyChanged(sender, e);
		}

		#endregion

		/*-----------------------------------------------------------------*/
		#region Internals

		void UpdateToggle()
		{
			if (Control != null && Element != null)
			{
				Control.Checked = Element.IsToggled;
			}
		}

		#endregion
	}
}