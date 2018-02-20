using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double lengt, double width, double height)
    {
        this.Length = lengt;
        this.Width = width;
        this.Height = height;
    }


    public double Length
    {
        get { return length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length cannot be zero or negative.");
            }
            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width cannot be zero or negative.");
            }
            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative.");
            }
            height = value;
        }
    }

    public double SurfaceArea
    {
        get
        {
          return this.CalculateSurfaceArea();
        }
    }

    public double LateralSurfaceArea
    {
        get
        {
            return this.CalculateLateralSurfaceArea();
        }
    }

    public double Volume
    {
        get
        {
            return this.CalculateVolume();
        }
    }

    private double CalculateSurfaceArea()
    {
        double surfaceArea = (2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height);
        return surfaceArea;
    }

    private double CalculateLateralSurfaceArea()
    {
        double lateralSurfaceArea = (2 * this.length * this.height) + (2 * this.width * this.height);
        return lateralSurfaceArea;
    }

    private double CalculateVolume()
    {
        double volume = this.length * this.width * this.height;
        return volume;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Surface Area - {SurfaceArea:F2}");
        builder.AppendLine($"Lateral Surface Area - {LateralSurfaceArea:F2}");
        builder.AppendLine($"Volume - {Volume:F2}");

        return builder.ToString().TrimEnd();
    }
}
