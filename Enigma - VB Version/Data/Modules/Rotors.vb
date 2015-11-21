Public Module Rotors
    ' Alphabet:
    Public ReadOnly Alpha = {" "c, "A"c, "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, "X"c, "Y"c, "Z"c}

    ' Rotors:
    ' Three Dimentional array reprezenting the position shift the rotors apply to the signal. Goes like this: Rotor(#ID, Signal Direction, Pos Shift)
    ' So for example, for determining how the singal would shift when going through Rotor I, from right to left, entering the letter E you would call Rotor(1,0,5)

    Public ReadOnly Rotor = {
                    {
                     {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                     {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                    }, {
                     {0, 4, 9, 10, 2, 7, 1, -3, 9, 13, -10, 3, 8, 2, 9, 10, -8, 7, 3, 0, -4, 6, -13, 5, -6, 4, 10},
                     {0, -6, -5, -4, 3, -4, -2, -1, 8, 13, -10, -9, -7, -10, -3, -2, 4, -9, 6, 0, -8, -3, -13, -9, -7, -10, 10}
                    }, {
                     {0, 0, 8, 1, 7, 14, 3, 11, 13, -11, -8, 1, -4, 10, 6, -2, 13, 0, -11, 7, -6, -5, 3, 9, -2, -10, 5},
                     {0, 0, 8, 13, -1, -5, -9, 11, 4, -3, -8, -7, -1, 2, 6, 10, 5, 0, -11, 12, -6, -13, 2, -10, 11, -3, -7}
                    }, {
                     {0, 1, 2, 3, 4, 5, 6, -4, 8, 9, 10, 13, 10, 13, 0, 10, -11, -8, 5, -12, 7, -10, -9, -2, -5, -8, -11},
                     {0, -7, -1, 4, -2, 11, -3, 12, -4, 8, -5, 10, -6, 9, 0, 11, -8, 8, -9, 5, -10, 2, -10, -5, 13, -10, 13}
                    }, {
                     {0, 4, -9, 12, -8, 11, -6, 3, -7, -10, 7, 10, -3, 5, -6, 9, -4, -3, -12, 1, 13, -10, 8, 6, -11, -2, 2},
                     {0, 7, -2, -6, -8, -4, 2, 13, 6, 3, -3, 10, 4, 12, 3, -12, -11, -7, -5, 9, -1, -10, -8, 2, -9, 10, 6}
                    }, {
                     {0, -5, -2, -1, -12, 2, 3, 13, -9, 12, 6, 8, -8, 1, -6, -3, 8, 10, 5, -7, -10, -4, -7, 9, 7, 4, 11},
                     {0, -10, 1, -4, 8, -7, -9, -2, 6, -3, 10, -11, 3, 6, -1, 7, -6, 4, 12, -8, -13, -12, 5, -5, -8, 9, 2}
                    }
                   }

    ' Turnover Notches:
    ' Each rotor has a turnover letter that, when reached shifts the left rotor by one position. The number represents the nth letter in the alphabet

    Public ReadOnly TurnNotch = {0, 17, 5, 22, 10, 26}

    ' Reflectors:
    ' Two Dimentional Array reprezenting the position shift the reflector applies to the signal. Goes like this: Reflector(#ID, Pos Shift)
    ' So for example, for determining how the signal would shift when going through Reflector B, entering the letter E you would call Reflector(2,5)

    Public ReadOnly Reflector = {
                                 {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                 {0, 4, 8, 10, 22, -4, 6, 18, 16, 13, -8, 12, -6, -10, 4, 2, 5, -2, -4, 1, -1, -5, -13, -12, -16, -18, -22},
                                 {0, -2, -10, -8, 4, 12, 13, 5, -4, 7, -12, 3, -5, 2, -3, -2, -7, -12, 10, 13, 6, 8, 1, -1, 12, 2, -6},
                                 {0, 5, -6, 13, 6, 4, -5, 8, -9, -4, -6, 7, -12, 11, 9, -8, 13, 3, -7, 2, -3, -2, 6, -9, -11, 9, 12}
                                }

End Module
