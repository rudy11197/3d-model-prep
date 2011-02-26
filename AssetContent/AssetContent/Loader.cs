#region File Description
//-----------------------------------------------------------------------------
// Author: JCBDigger
// URL: http://Games.DiscoverThat.co.uk
//-----------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AssetContent
{
    /// <summary>
    /// Used to load and store pre-built content
    /// </summary>
    public class Loader
    {
        ContentManager Content;

        public Loader(IServiceProvider serviceProvider)
        {
            Content = new ContentManager(serviceProvider, "Content");
        }

        public Model GetModel(string shortName)
        {
            return Content.Load<Model>(shortName);
        }

    }
}
