using System;
using System.Collections.Generic;
using System.Text;

namespace GolfHandicapMobile.Behaviors
{
    using System.Text.RegularExpressions;
    using Xamarin.Forms;

    public class MaskedBehavior : Behavior<Entry>
    {
        #region Fields

        /// <summary>
        /// The mask
        /// </summary>
        private String MaskValue = "";

        /// <summary>
        /// The positions
        /// </summary>
        private IDictionary<Int32, Char> Positions;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the mask.
        /// </summary>
        /// <value>
        /// The mask.
        /// </value>
        public String Mask
        {
            get => this.MaskValue;
            set
            {
                this.MaskValue = value;
                this.SetPositions();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [attached to].
        /// </summary>
        /// <param name="entry">The entry.</param>
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += this.OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        /// <summary>
        /// Called when [detaching from].
        /// </summary>
        /// <param name="entry">The entry.</param>
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= this.OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        /// <summary>
        /// Called when [entry text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void OnEntryTextChanged(Object sender,
                                        TextChangedEventArgs args)
        {
            Entry entry = sender as Entry;

            String text = entry.Text;

            if (String.IsNullOrWhiteSpace(text) || this.Positions == null)
            {
                return;
            }

            if (text.Length > this.MaskValue.Length)
            {
                entry.Text = text.Remove(text.Length - 1);
                return;
            }

            foreach (KeyValuePair<Int32, Char> position in this.Positions)
            {
                if (text.Length >= position.Key + 1)
                {
                    String value = position.Value.ToString();
                    if (text.Substring(position.Key, 1) != value)
                    {
                        text = text.Insert(position.Key, value);
                    }
                }
            }

            if (entry.Text != text)
            {
                entry.Text = text;
            }
        }

        /// <summary>
        /// Sets the positions.
        /// </summary>
        private void SetPositions()
        {
            if (String.IsNullOrEmpty(this.MaskValue))
            {
                this.Positions = null;
                return;
            }

            Dictionary<Int32, Char> list = new Dictionary<Int32, Char>();
            for (Int32 i = 0; i < this.Mask.Length; i++)
            {
                if (this.MaskValue[i] != 'X')
                {
                    list.Add(i, this.MaskValue[i]);
                }
            }

            this.Positions = list;
        }

        #endregion
    }
}
