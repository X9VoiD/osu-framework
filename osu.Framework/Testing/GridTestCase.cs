﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using OpenTK;
using osu.Framework.Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace osu.Framework.Testing
{
    /// <summary>
    /// An abstract test case which exposes small cells arranged in a grid.
    /// Useful for displaying multiple configurations of a tested component at a glance.
    /// </summary>
    public abstract class GridTestCase : TestCase
    {
        private readonly GridContainer testContainer;

        private readonly Container[,] cells;

        /// <summary>
        /// The amount of rows in the grid.
        /// </summary>
        protected readonly int Rows;

        /// <summary>
        /// The amount of columns in the grid.
        /// </summary>
        protected readonly int Cols;

        /// <summary>
        /// Constructs a grid test case with the given dimensions.
        /// </summary>
        protected GridTestCase(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;

            Add(testContainer = new GridContainer { RelativeSizeAxes = Axes.Both });

            cells = new Container[rows, cols];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    cells[r, c] = new Container { RelativeSizeAxes = Axes.Both };

            testContainer.Content = cells.ToJagged();
        }

        protected Container Cell(int index) => cells[index / Cols, index % Cols];
        protected Container Cell(int row, int col) => cells[row, col];
    }
}
