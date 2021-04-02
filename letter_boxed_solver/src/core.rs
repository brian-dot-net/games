use std::{
    fmt::{self, Display, Formatter},
    hash::Hash,
    ops::{Add, Index},
    str::FromStr,
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

impl From<char> for Ch {
    fn from(c: char) -> Self {
        match c {
            'A' => Ch::A,
            'B' => Ch::B,
            'C' => Ch::C,
            'D' => Ch::D,
            'E' => Ch::E,
            'F' => Ch::F,
            'G' => Ch::G,
            'H' => Ch::H,
            'I' => Ch::I,
            'J' => Ch::J,
            'K' => Ch::K,
            'L' => Ch::L,
            'M' => Ch::M,
            'N' => Ch::N,
            'O' => Ch::O,
            'P' => Ch::P,
            'Q' => Ch::Q,
            'R' => Ch::R,
            'S' => Ch::S,
            'T' => Ch::T,
            'U' => Ch::U,
            'V' => Ch::V,
            'W' => Ch::W,
            'X' => Ch::X,
            'Y' => Ch::Y,
            'Z' => Ch::Z,
            _ => Ch::None,
        }
    }
}

impl Display for Ch {
    fn fmt(&self, f: &mut Formatter) -> fmt::Result {
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

#[derive(Clone, Copy, Debug, Eq, Hash, PartialEq)]
pub struct St(u64);

impl St {
    pub fn empty() -> St {
        St(0)
    }

    pub fn len(&self) -> u8 {
        (self.0 & 0xF) as u8
    }

    pub fn chop(&self) -> St {
        if self.len() == 0 {
            panic!("Cannot chop any more");
        }

        let mask = !(0x1F << (self.len() * 5 - 1));
        St((self.0 - 1) & mask)
    }
}

impl Display for St {
    fn fmt(&self, f: &mut Formatter) -> fmt::Result {
        for i in 0..self.len() {
            let r = write!(f, "{}", self[i]);
            if r.is_err() {
                return r;
            }
        }

        Ok(())
    }
}

impl FromStr for St {
    type Err = ();

    fn from_str(s: &str) -> Result<St, ()> {
        let mut value = St::empty();
        for c in s.chars() {
            let c = Ch::from(c);
            value = value + c;
        }

        Ok(value)
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
    use std::{
        collections::{hash_map::DefaultHasher, HashSet},
        hash::Hasher,
    };

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
    fn append_too_many() {
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
    fn index_too_big() {
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
    fn chop_empty() {
        let s = St::empty();

        let _ = s.chop();
    }

    #[test]
    fn chop_chars() {
        let s = St::empty()
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

        let s = s.chop();
        assert_eq!(11, s.len());
        assert_eq!("ABCDEFGHIJK", s.to_string());

        let s = s.chop();
        assert_eq!(10, s.len());
        assert_eq!("ABCDEFGHIJ", s.to_string());

        let s = s.chop();
        assert_eq!(9, s.len());
        assert_eq!("ABCDEFGHI", s.to_string());

        let s = s.chop();
        assert_eq!(8, s.len());
        assert_eq!("ABCDEFGH", s.to_string());

        let s = s.chop();
        assert_eq!(7, s.len());
        assert_eq!("ABCDEFG", s.to_string());

        let s = s.chop();
        assert_eq!(6, s.len());
        assert_eq!("ABCDEF", s.to_string());

        let s = s.chop();
        assert_eq!(5, s.len());
        assert_eq!("ABCDE", s.to_string());

        let s = s.chop();
        assert_eq!(4, s.len());
        assert_eq!("ABCD", s.to_string());

        let s = s.chop();
        assert_eq!(3, s.len());
        assert_eq!("ABC", s.to_string());

        let s = s.chop();
        assert_eq!(2, s.len());
        assert_eq!("AB", s.to_string());

        let s = s.chop();
        assert_eq!(1, s.len());
        assert_eq!("A", s.to_string());

        let s = s.chop();
        assert_eq!(0, s.len());
        assert_eq!("", s.to_string());
    }

    #[test]
    fn equality() {
        let empty = St::empty();
        let a = St::empty() + Ch::A;
        let b = St::empty() + Ch::B;
        let ab = St::empty() + Ch::A + Ch::B;
        let ba = St::empty() + Ch::B + Ch::A;
        let cdefgh = St::empty() + Ch::C + Ch::D + Ch::E + Ch::F + Ch::G + Ch::H;

        assert_ne!(empty, a);
        assert_eq!(empty, empty);
        assert_eq!(a, a);
        assert_ne!(a, b);
        assert_ne!(ab, ba);
        assert_eq!(ba, ba);
        assert_ne!(cdefgh, ba);
        assert_eq!(cdefgh, cdefgh);
    }

    #[test]
    fn hash_code() {
        let empty = St::empty();
        let a = St::empty() + Ch::A;
        let b = St::empty() + Ch::B;
        let ab = St::empty() + Ch::A + Ch::B;
        let ba = St::empty() + Ch::B + Ch::A;
        let cdefgh = St::empty() + Ch::C + Ch::D + Ch::E + Ch::F + Ch::G + Ch::H;
        let values = vec![empty, a, b, ab, ba, cdefgh];

        let codes: HashSet<u64> = values
            .into_iter()
            .map(|s| {
                let mut hasher = DefaultHasher::new();
                s.hash(&mut hasher);
                hasher.finish()
            })
            .collect();
        assert_eq!(6, codes.len());
    }

    #[test]
    fn parse_from_string() {
        test_parse("");
        test_parse("A");
        test_parse("BC");
        test_parse("DEF");
        test_parse("GHIJ");
        test_parse("KLMNO");
        test_parse("PQRSTU");
        test_parse("VWXYZAB");
        test_parse("CDEFGHIJ");
        test_parse("KLMNOPQRS");
        test_parse("TUVWXYZABC");
        test_parse("DEFGHIJKLMN");
        test_parse("OPQRSTUVWXYZ");
    }

    fn test_parse(expected: &str) {
        let s = expected.parse::<St>().unwrap();
        assert_eq!(expected, s.to_string());
    }
}
