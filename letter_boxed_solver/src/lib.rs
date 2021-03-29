use std::{
    fmt::{Display, Formatter, Result},
    ops::{Add, Index},
};

#[derive(Clone, Copy, Debug, PartialEq)]
pub enum Ch {
    None,
    A,
}

impl Display for Ch {
    fn fmt(&self, f: &mut Formatter) -> Result {
        let s = match self {
            Ch::None => "",
            Ch::A => "A",
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
}

impl Display for St {
    fn fmt(&self, f: &mut Formatter) -> Result {
        write!(f, "{}", self[0])
    }
}

impl Index<u8> for St {
    type Output = Ch;

    fn index(&self, index: u8) -> &Self::Output {
        let c = (self.0 >> (4 + 5 * index)) & 0x1F;
        match c {
            1 => &Ch::A,
            _ => &Ch::None,
        }
    }
}

impl Add<Ch> for St {
    type Output = St;

    fn add(self, _rhs: Ch) -> Self::Output {
        St(0x11)
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
}
