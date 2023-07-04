using System;
using BitComponents;
using LongwordComponents;
using RippleAdderComponents;

namespace MultiplierComponents
{
    public class Multiplier 
    {
        public static Longword MULTIPLY(Longword Multicand, Longword Multiplier) 
        {
            Longword Product = new(0);
            for(int Position = 31; Position >= 0; Position--)
            {
                if(Multiplier.GetBit(Position).GetValue() == 1) // Find last 1 in multiplier.
                {
                    Product = RippleAdder.ADD(Product, Multicand); // Found; Add multicand to result.
                }
                Multicand = Multicand.LeftShift(1); // Shift multicand to the left by 1.
            }
            return Product;
        }
    }
}