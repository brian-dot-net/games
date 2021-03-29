use std::{
    fmt::{Display, Formatter, Result},
    ops::Index,
};

#[derive(Clone, Copy, Debug, PartialEq)]
pub enum Ch {
    None,
}

pub struct St(u64);

impl St {
    fn empty() -> St {
        St(0)
    }

    fn len(&self) -> u8 {
        0
    }
}

impl Display for St {
    fn fmt(&self, f: &mut Formatter) -> Result {
        write!(f, "{}", "")
    }
}

impl Index<u8> for St {
    type Output = Ch;

    fn index(&self, _index: u8) -> &Self::Output {
        &Ch::None
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
}
