use crate::core::{Ch, St, Vertices};
use std::{
    collections::{HashMap, HashSet},
    hash::Hash,
};

#[derive(Eq, PartialEq)]
struct Word {
    word: St,
    verts: Vertices,
}

impl Word {
    fn last(&self) -> Ch {
        self.word[self.word.len() - 1]
    }

    fn is_solution_with(&self, other: &Word) -> bool {
        let v = self.verts + other.verts;
        v.is_complete()
    }
}

impl Hash for Word {
    fn hash<H: std::hash::Hasher>(&self, state: &mut H) {
        self.word.hash(state)
    }
}

pub struct LetterBoxWords(HashMap<Ch, HashSet<Word>>);

impl LetterBoxWords {
    fn new() -> LetterBoxWords {
        LetterBoxWords(HashMap::new())
    }

    fn insert(&mut self, word: St, verts: Vertices) {
        let k = word[0];
        let w = Word { word, verts };
        if let Some(v) = self.0.get_mut(&k) {
            v.insert(w);
        } else {
            let mut v = HashSet::new();
            v.insert(w);
            self.0.insert(k, v);
        }
    }

    fn find<F>(&self, mut found: F)
    where
        F: FnMut(St, St),
    {
        for w1 in self.0.values().flat_map(|v| v) {
            if let Some(v) = self.0.get(&w1.last()) {
                for w2 in v {
                    if w1.is_solution_with(&w2) {
                        found(w1.word, w2.word);
                    }
                }
            }
        }
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn empty_finds_nothing() {
        let words = LetterBoxWords::new();

        let expected: Vec<&str> = vec![];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn one_word_finds_nothing() {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ALE", 0b100000010001);

        let expected: Vec<&str> = vec![];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn two_words_invalid_solution_finds_0() {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ALE", 0b100000010001);
        insert_word(&mut words, "ELF", 0b100000110000);

        let expected: Vec<&str> = vec![];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn two_words_valid_solution_finds_1() {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ADBECF", 0b000000111111);
        insert_word(&mut words, "FGJHKIL", 0b111111100000);

        let expected = vec!["ADBECF-FGJHKIL"];
        assert_eq!(expected, solutions(&words));
    }

    #[test]
    fn many_words_finds_all_solutions() {
        let mut words = LetterBoxWords::new();
        insert_word(&mut words, "ADB", 0b000000001011);
        insert_word(&mut words, "ADBECF", 0b000000111111);
        insert_word(&mut words, "BECFHJGKIL", 0b111111111110);
        insert_word(&mut words, "FGJHKIL", 0b111111100000);
        insert_word(&mut words, "FAHKILJG", 0b111111100001);
        insert_word(&mut words, "FAHKILJ", 0b111110100001);

        let expected = vec!["ADB-BECFHJGKIL", "ADBECF-FAHKILJG", "ADBECF-FGJHKIL"];
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
