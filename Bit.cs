using System;

namespace BitComponents
{
    public interface IBit
    {
        public void Set(int Value);

        public void Toggle();

        public void Set();

        public void Clear();

        public int GetValue();

        public Bit AND(params Bit[] Other);

        public Bit OR(params Bit[] Other);

        public Bit XOR(params Bit[] Other);

        public Bit NOT();
    }


    public class Bit : IBit
    {
        public Bit(int State)
        {
            this.State = State;
        }

        public Bit() 
        {
            State = 0;
        }

        private int State; // Bit state; 0 (off, default) or 1 (on).

        public void Set(int Value) // Set bit state with specific value.
        {
            this.State = Value;
        }

        public void Toggle() // Toggle bit state.
        {
            if (this.State == 0)
            {
                this.State = 1;
            }
            else
            {
                this.State = 0;
            }
        }

        public void Set() // Set bit state to 1.
        {
            this.State = 1;
        }

        public void Clear() // Clear bit state to 0.
        { 
            this.State = 0; 
        }

        public int GetValue() // Return value of the bit's state.
        {
            return this.State;
        }

        public Bit AND(params Bit[] Other) // Uses AND operator on two bits and returns a new bit.
        {
            if(this.State == 0) return new Bit(0);
            for(int i = 0; i < Other.Length; i++) {
                if(Other[i].State == 0) {
                    return new Bit(0);
                }
                Other = Other.Skip(1).ToArray();
            }
            return new Bit(1);
        }

        public Bit OR(params Bit[] Other) // Uses OR operator on two or more bits and returns a new bit.
        {
            if(this.State == 1) return new Bit(1);
            foreach(Bit CurrentBit in Other) {
                if(CurrentBit.State == 1) return new Bit(1);
            }
            return new Bit(0);
        }

        public Bit XOR(params Bit[] Other) // Uses XOR operator on two bits and returns a new bit.
        {
            for(int i = 0; i < Other.Length; i++) {
                if(this.State == Other[i].State) {
                    return new Bit(0);
                }
                Other = Other.Skip(1).ToArray();
            }
            return new Bit(1);
        }

        public Bit NOT() // Uses NOT operator on current bit and returns a new bit.
        {
            if(this.State == 0) return new Bit(1);
            return new Bit(0);
        }
        public override string ToString()
        {
            return GetValue() + "";
        }
    }
}