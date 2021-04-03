use crate::core::{St, Vertices};

pub struct LetterBoxWords;

impl LetterBoxWords {
    fn new() -> LetterBoxWords {
        LetterBoxWords
    }

    fn insert(&mut self, word: St, verts: Vertices) {}

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

    #[test]
    fn one_word_finds_nothing() {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ALE", 0b100000010001);

        let expected: Vec<String> = vec![];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn two_words_invalid_solution_finds_0()    {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ALE", 0b100000010001);
        insert_word(&mut words, "ELF", 0b100000110000);

        let expected: Vec<String> = vec![];
        assert_eq!(expected, solutions(&words));
    }

    fn insert_word(words: &mut LetterBoxWords, word: &str, bits: u16) {
        words.insert(word.parse::<St>().unwrap(), Vertices::new(bits));
    }

    fn solutions(words: &LetterBoxWords) -> Vec<String> {
        let mut found = vec![];

        words.find(|w1, w2| found.push(format!("{}-{}", w1, w2)));

        found.sort();
        found
    }
}
