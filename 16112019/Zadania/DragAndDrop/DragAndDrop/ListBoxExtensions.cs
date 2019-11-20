﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DragAndDrop
{
    public static class ListBoxExtensions
    {
        public static ListBoxItem GetItemAt(ListBox listBox, Point position)
        {
            DependencyObject item = VisualTreeHelper.HitTest(listBox, position).VisualHit;

            while (item != null && !(item is ListBoxItem))
                item = VisualTreeHelper.GetParent(item);

            return item as ListBoxItem;
        }

        public static int IndexFromPoint(ListBox listBox, Point position)
        {
            ListBoxItem item = GetItemAt(listBox, position);
            return listBox.Items.IndexOf(item);
        }
    }
}
