use std::{
    fmt::{Display, Formatter, Result},
    ops::{Add, Index},
};

#[derive(Clone, Copy, Debug, PartialEq)]
pub enum Ch {
    None,
    A,
    B,
    C,
    D,
    E,
    F,
    G,
    H,
    I,
    J,
    K,
    L,
    M,
    N,
    O,
    P,
    Q,
    R,
    S,
    T,
    U,
    V,
    W,
    X,
    Y,
    Z,
}

impl Display for Ch {
    fn fmt(&self, f: &mut Formatter) -> Result {
        let s = match self {
            Ch::None => "",
            Ch::A => "A",
            Ch::B => "B",
            Ch::C => "C",
            Ch::D => "D",
            Ch::E => "E",
            Ch::F => "F",
            Ch::G => "G",
            Ch::H => "H",
            Ch::I => "I",
            Ch::J => "J",
            Ch::K => "K",
            Ch::L => "L",
            Ch::M => "M",
            Ch::N => "N",
            Ch::O => "O",
            Ch::P => "P",
            Ch::Q => "Q",
            Ch::R => "R",
            Ch::S => "S",
            Ch::T => "T",
            Ch::U => "U",
            Ch::V => "V",
            Ch::W => "W",
            Ch::X => "X",
            Ch::Y => "Y",
            Ch::Z => "Z",
        };
        write!(f, "{}", s)
    }
}

pub struct St(u64);

impl St {
    fn empty() -> St {
        St(0)
    }

    fn len(&self) -> u8 {
        (self.0 & 0xF) as u8
    }

    fn chop(&self) -> St {
        panic!("Cannot chop any more");
    }
}

impl Display for St {
    fn fmt(&self, f: &mut Formatter) -> Result {
        for i in 0..self.len() {
            let r = write!(f, "{}", self[i]);
            if r.is_err() {
                return r;
            }
        }

        Ok(())
    }
}

impl Index<u8> for St {
    type Output = Ch;

    fn index(&self, index: u8) -> &Self::Output {
        if index >= 12 {
            panic!("Out of range");
        }

        let c = (self.0 >> (4 + 5 * index)) & 0x1F;
        match c {
            1 => &Ch::A,
            2 => &Ch::B,
            3 => &Ch::C,
            4 => &Ch::D,
            5 => &Ch::E,
            6 => &Ch::F,
            7 => &Ch::G,
            8 => &Ch::H,
            9 => &Ch::I,
            10 => &Ch::J,
            11 => &Ch::K,
            12 => &Ch::L,
            13 => &Ch::M,
            14 => &Ch::N,
            15 => &Ch::O,
            16 => &Ch::P,
            17 => &Ch::Q,
            18 => &Ch::R,
            19 => &Ch::S,
            20 => &Ch::T,
            21 => &Ch::U,
            22 => &Ch::V,
            23 => &Ch::W,
            24 => &Ch::X,
            25 => &Ch::Y,
            26 => &Ch::Z,
            _ => &Ch::None,
        }
    }
}

impl Add<Ch> for St {
    type Output = St;

    fn add(self, rhs: Ch) -> Self::Output {
        if self.len() == 12 {
            panic!("Cannot append any more");
        }

        let c = match rhs {
            Ch::None => 0,
            Ch::A => 1,
            Ch::B => 2,
            Ch::C => 3,
            Ch::D => 4,
            Ch::E => 5,
            Ch::F => 6,
            Ch::G => 7,
            Ch::H => 8,
            Ch::I => 9,
            Ch::J => 10,
            Ch::K => 11,
            Ch::L => 12,
            Ch::M => 13,
            Ch::N => 14,
            Ch::O => 15,
            Ch::P => 16,
            Ch::Q => 17,
            Ch::R => 18,
            Ch::S => 19,
            Ch::T => 20,
            Ch::U => 21,
            Ch::V => 22,
            Ch::W => 23,
            Ch::X => 24,
            Ch::Y => 25,
            Ch::Z => 26,
        };
        St((self.0 + 1) | (c << (4 + 5 * self.len())))
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn empty() {
        let s = St::empty();

        assert_eq!(0, s.len());
        assert_eq!("", s.to_string());
        let expected = vec![
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
        ];
        let actual: Vec<Ch> = (0..12).map(|i| s[i]).collect();
        assert_eq!(expected, actual);
    }

    #[test]
    fn one_char() {
        let s = St::empty() + Ch::A;

        assert_eq!(1, s.len());
        assert_eq!("A", s.to_string());
        let expected = vec![
            Ch::A,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
        ];
        let actual: Vec<Ch> = (0..12).map(|i| s[i]).collect();
        assert_eq!(expected, actual);
    }

    #[test]
    fn two_chars() {
        let s = St::empty() + Ch::B + Ch::C;

        assert_eq!(2, s.len());
        assert_eq!("BC", s.to_string());
        let expected = vec![
            Ch::B,
            Ch::C,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
        ];
        let actual: Vec<Ch> = (0..12).map(|i| s[i]).collect();
        assert_eq!(expected, actual);
    }

    #[test]
    fn four_chars() {
        let s = St::empty() + Ch::D + Ch::E + Ch::F + Ch::G;

        assert_eq!(4, s.len());
        assert_eq!("DEFG", s.to_string());
        let expected = vec![
            Ch::D,
            Ch::E,
            Ch::F,
            Ch::G,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
        ];
        let actual: Vec<Ch> = (0..12).map(|i| s[i]).collect();
        assert_eq!(expected, actual);
    }

    #[test]
    fn eight_chars() {
        let s = St::empty() + Ch::H + Ch::I + Ch::J + Ch::K + Ch::L + Ch::M + Ch::N + Ch::O;

        assert_eq!(8, s.len());
        assert_eq!("HIJKLMNO", s.to_string());
        let expected = vec![
            Ch::H,
            Ch::I,
            Ch::J,
            Ch::K,
            Ch::L,
            Ch::M,
            Ch::N,
            Ch::O,
            Ch::None,
            Ch::None,
            Ch::None,
            Ch::None,
        ];
        let actual: Vec<Ch> = (0..12).map(|i| s[i]).collect();
        assert_eq!(expected, actual);
    }

    #[test]
    fn twelve_chars() {
        let s = St::empty()
            + Ch::P
            + Ch::Q
            + Ch::R
            + Ch::S
            + Ch::T
            + Ch::U
            + Ch::V
            + Ch::W
            + Ch::X
            + Ch::Y
            + Ch::Z
            + Ch::A;

        assert_eq!(12, s.len());
        assert_eq!("PQRSTUVWXYZA", s.to_string());
        let expected = vec![
            Ch::P,
            Ch::Q,
            Ch::R,
            Ch::S,
            Ch::T,
            Ch::U,
            Ch::V,
            Ch::W,
            Ch::X,
            Ch::Y,
            Ch::Z,
            Ch::A,
        ];
        let actual: Vec<Ch> = (0..12).map(|i| s[i]).collect();
        assert_eq!(expected, actual);
    }

    #[test]
    #[should_panic(expected = "Cannot append any more")]
    fn append_too_many()
    {
        let max = St::empty()
            + Ch::A
            + Ch::B
            + Ch::C
            + Ch::D
            + Ch::E
            + Ch::F
            + Ch::G
            + Ch::H
            + Ch::I
            + Ch::J
            + Ch::K
            + Ch::L;

        let _ = max + Ch::X;
    }

    #[test]
    #[should_panic(expected = "Out of range")]
    fn index_too_big()
    {
        let max = St::empty()
            + Ch::A
            + Ch::B
            + Ch::C
            + Ch::D
            + Ch::E
            + Ch::F
            + Ch::G
            + Ch::H
            + Ch::I
            + Ch::J
            + Ch::K
            + Ch::L;

        let _ = max[12];
    }

    #[test]
    #[should_panic(expected = "Cannot chop any more")]
    fn chop_empty()
    {
        let s = St::empty();

        let _ = s.chop();
    }
}
