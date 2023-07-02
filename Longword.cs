using BitComponents;

namespace LongwordComponents 
{    
    public interface ILongword
    {
        public Bit GetBit(int i);

        public void SetBit(int i, Bit Value);

        public Longword AND(Longword Other);

        public Longword OR(Longword Other);

        public Longword XOR(Longword Other);

        public Longword NOT();
        
        public Longword LeftShift(int Amount);

        public Longword RightShift(int Amount);
                
        public long GetUnsigned();
        
        public int GetSigned();
        
        public void Copy(Longword Other);
        
        public void Set(int Value);
    }

    public class Longword : ILongword {

        public Longword(Bit[] Bits)
        { 
            this.Bits = Bits;
        }

        public Longword(int Value) 
        {
            for(int i = 0; i < 32; i++) 
            {
                this.Bits[i].Set(Value);
            }
        }

        private Bit[] Bits = new Bit[32];

        public Bit GetBit(int i) // Get bit of longword at position i.
        {
            return this.Bits[i];
        }

        public void SetBit(int i, Bit Value) // Set bit of longword at i to value.
        {
            this.Bits[i] = Value;
        }

        public Longword AND(Longword Other) // Uses AND operator on two longwords and returns a new longword.
        {
            Bit[] TempArray = new Bit[32];
            for(int i = 0; i < 32; i++) TempArray[i] = this.Bits[i].AND(Other.Bits[i]);
            return new Longword(TempArray);
        }

        public Longword OR(Longword Other) // Uses OR operator on two longwords and returns a new longword.
        {
            Bit[] TempArray = new Bit[32];
            for(int i = 0; i < 32; i++) TempArray[i] = this.Bits[i].OR(Other.Bits[i]);
            return new Longword(TempArray);
        }

        public Longword XOR(Longword Other) // Uses XOR operator on two longwords and returns a new longword.
        {
            Bit[] TempArray = new Bit[32];
            for(int i = 0; i < 32; i++) TempArray[i] = this.Bits[i].XOR(Other.Bits[i]);
            return new Longword(TempArray);
        }

        public Longword NOT() // Uses NOT operator on current longword and returns a new longword.
        {
            Bit[] TempArray = new Bit[32];
            for(int i = 0; i < 32; i++) TempArray[i] = this.Bits[i].NOT();
            return new Longword(TempArray);
        }

        public Longword LeftShift(int Amount) // Left shifts current longword by amount many bits then returns a new longword.
        {
            // DOESNT NEED FIXING BUT MAYBE DONT USE FUNCTIONS LIKE RESIZE AND SKIP AND STUFF?
            Bit[] TempArray;
            TempArray = this.Bits;
            for(int i = 0; i < Amount; i++) 
            {
                TempArray = TempArray.Skip(1).ToArray();
                Array.Resize<Bit>(ref TempArray, 32);
                TempArray[31] = new Bit(0);
            }
            return new Longword(TempArray);
        }

        public Longword RightShift(int Amount) // Right shifts current longword by amount many bits then returns a new longword.
        {
            // DOESNT NEED FIXING BUT MAYBE CHANGE IT?
            Bit[] TempArray = new Bit[32];
            for(int n = 0; n < Amount; n++)
            {
                for (int i = 0; i < 32; i++) {
                    TempArray[(i+1) % 32] = this.Bits[i];
                }
                TempArray[0] = new Bit(0);
            }
            return new Longword(TempArray);
        }
        
        public long GetUnsigned() // Returns the value of current longword as a long.
        {
            long Factor = 1;
            long Total = 0;
            for(int i = 31; i >= 0; i--)
            {
                if(this.Bits[i].GetValue() == 1) Total += Factor;
                Factor *= 2;
            }
            return Total;
        }
        
        public int GetSigned() // Returns the value of current longword as an int.
        {
            int Factor = 1;
            int Total = 0;
            if(this.Bits[0].GetValue() == 1) Total += -2147483648;
            for(int i = 31; i >= 1; i--)
            {
                if(this.Bits[i].GetValue() == 1) Total += Factor;
                Factor *= 2;
            }
            return Total;
        }
        
        public void Copy(Longword Other) // Copies the values of the bits from other longword into current one.
        {
            this.Bits = Other.Bits;
        }
        
        public void Set(int Value) // Set the value of the bits of current longword (used for tests).
        {
            int Factor = 1073741824;
            SetBit(0, new Bit(0));
            if(Value < 0) {
                SetBit(0, new Bit(1));
                Value *= -1;
            }
            for(int i = 1; i <= 31; i++) 
            {
                if(Value >= Factor) 
                {
                    Value -= Factor;
                    SetBit(i, new Bit(1));
                }
                else 
                {
                    SetBit(i, new Bit(0));
                }
                Factor /= 2;
            }
        }

        public override string ToString()
        {
            string TempString = "";
            foreach(Bit x in this.Bits) 
            {
                TempString += x.GetValue().ToString() + "";
            }
            return TempString;
        }

    }

}