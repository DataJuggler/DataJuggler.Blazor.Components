

#region using statements

using DataJuggler.Blazor.Components.Enumerations;
using System;

#endregion

namespace DataJuggler.Blazor.Components
{

    #region class Item
    /// <summary>
    /// This class is used by the ComboBox to set the values
    /// </summary>
    public class Item
    {
        
        #region Private Variables
        private string caption;
        private int id;
        private ImageAlignmentEnum imageAlignment;
        private double imageHeight;
        private string imageUrl;
        private double imageWidth;
        private bool includeImage;
        private bool itemChecked;
        private bool includeCaptionInToString;
        private string name;
        private string text;
        #endregion
        
        #region Constructors
            
            #region Constructor
            /// <summary>
            /// Create a new instance of a 'Item' object.
            /// </summary>
            public Item()
            {
            }
            #endregion
            
            #region Constructor
            /// <summary>
            /// Create a new instance of a 'Item' object.
            /// </summary>
            public Item(int id, string name, string text)
            {
                // store args
                Id = id;
                Name = name;
                Text = text;
            }
        #endregion

        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// method returns the Caption - Text
            /// </summary>
            public override string ToString()
            {
                // initial value
                string toString = Text;

                // if the value for HasCaption is true
                if ((HasCaption) && (IncludeCaptionInToString))
                {
                    // set the return value
                    toString = Caption + " - " + Text;
                }

                // return value
                return toString;
            }
            #endregion
            
        #endregion

        #region Properties

            #region Caption
            /// <summary>
            /// This property gets or sets the value for 'Caption'.
            /// </summary>
            public string Caption
            {
                get { return caption; }
                set { caption = value; }
            }
            #endregion
            
            #region HasCaption
            /// <summary>
            /// This property returns true if the 'Caption' exists.
            /// </summary>
            public bool HasCaption
            {
                get
                {
                    // initial value
                    bool hasCaption = (!String.IsNullOrEmpty(Caption));

                    // return value
                    return hasCaption;
                }
            }
            #endregion
            
            #region Id
            /// <summary>
            /// This property gets or sets the value for 'Id'.
            /// </summary>
            public int Id
            {
                get { return id; }
                set { id = value; }
            }
            #endregion
            
            #region ImageAlignment
            /// <summary>
            /// This property gets or sets the value for 'ImageAlignment'.
            /// </summary>
            public ImageAlignmentEnum ImageAlignment
            {
                get { return imageAlignment; }
                set { imageAlignment = value; }
            }
            #endregion
            
            #region ImageHeight
            /// <summary>
            /// This property gets or sets the value for 'ImageHeight'.
            /// </summary>
            public double ImageHeight
            {
                get { return imageHeight; }
                set { imageHeight = value; }
            }
            #endregion
            
            #region ImageUrl
            /// <summary>
            /// This property gets or sets the value for 'ImageUrl'.
            /// </summary>
            public string ImageUrl
            {
                get { return imageUrl; }
                set { imageUrl = value; }
            }
            #endregion
            
            #region ImageWidth
            /// <summary>
            /// This property gets or sets the value for 'ImageWidth'.
            /// </summary>
            public double ImageWidth
            {
                get { return imageWidth; }
                set { imageWidth = value; }
            }
            #endregion
            
            #region IncludeCaptionInToString
            /// <summary>
            /// This property gets or sets the value for 'IncludeCaptionInToString'.
            /// </summary>
            public bool IncludeCaptionInToString
            {
                get { return includeCaptionInToString; }
                set { includeCaptionInToString = value; }
            }
            #endregion
            
            #region IncludeImage
            /// <summary>
            /// This property gets or sets the value for 'IncludeImage'.
            /// </summary>
            public bool IncludeImage
            {
                get { return includeImage; }
                set { includeImage = value; }
            }
            #endregion
            
            #region ItemChecked
            /// <summary>
            /// This property gets or sets the value for 'ItemChecked'.
            /// </summary>
            public bool ItemChecked
            {
                get { return itemChecked; }
                set { itemChecked = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Text
            /// <summary>
            /// This property gets or sets the value for 'Text'.
            /// </summary>
            public string Text
            {
                get { return text; }
                set { text = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
