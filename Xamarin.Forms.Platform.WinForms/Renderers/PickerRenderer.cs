﻿using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Xamarin.Forms.Platform.WinForms
{
	public class PickerRenderer : ViewRenderer<Picker, System.Windows.Forms.ComboBox>
	{
		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				e.OldElement.Items.RemoveCollectionChangedEvent(OnCollectionChanged);
			}
			if (e.NewElement != null)
			{
				e.NewElement.Items.AddCollectionChangedEvent(OnCollectionChanged);
				Control.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
				Control.SelectedIndexChanged += Platform.BlockRenter((s, e2) => Element.SelectedIndex = Control.SelectedIndex);

				UpdateItems();
				UpdateSelectedIndex();
				UpdateTextColor();
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Picker.SelectedIndexProperty.PropertyName)
			{
				UpdateSelectedIndex();
			}
			else if (e.PropertyName == Picker.TextColorProperty.PropertyName)
			{
				UpdateTextColor();
			}

			base.OnElementPropertyChanged(sender, e);
		}

		#endregion

		/*-----------------------------------------------------------------*/
		#region Internals

		void UpdateSelectedIndex()
		{
			if (Control != null && Element != null)
			{
				Control.SelectedIndex = Element.SelectedIndex;
			}
		}

		void UpdateTextColor()
		{
			if (Control != null && Element != null)
			{
				Control.ForeColor = Element.TextColor.ToWindowsColor();
			}
		}


		void UpdateItems()
		{
			Control.Items.Clear();
			int count = Element.Items.Count;
			foreach (var item in Element.Items)
			{
				Control.Items.Add(item);
			}
		}

		void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			UpdateItems();
			UpdateSelectedIndex();
		}


		#endregion
	}
}