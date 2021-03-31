pub struct StTrie;

impl StTrie {
    fn new() -> StTrie {
        StTrie
    }

    fn len(&self) -> usize {
        0
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn empty() {
        let trie = StTrie::new();

        assert_eq!(0, trie.len());
    }
}