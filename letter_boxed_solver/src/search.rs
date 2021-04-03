use crate::core::St;

pub struct LetterBoxWords;

impl LetterBoxWords {
    fn new() -> LetterBoxWords {
        LetterBoxWords
    }

    fn find<F>(&self, found: F)
    where
        F: FnMut(St, St),
    {
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn empty_finds_nothing() {
        let words = LetterBoxWords::new();

        let expected: Vec<String> = vec![];
        assert_eq!(expected, solutions(&words));
    }

    fn solutions(words: &LetterBoxWords) -> Vec<String> {
        let mut found = vec![];

        words.find(|w1, w2| found.push(format!("{}-{}", w1, w2)));

        found.sort();
        found
    }
}
