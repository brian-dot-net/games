use crate::core::St;
use std::collections::HashMap;

#[derive(Debug, PartialEq)]
pub enum NodeKind {
    None,
    Prefix,
    Terminal,
}

pub struct StTrie {
    nodes: HashMap<St, bool>,
    count: usize,
}

impl StTrie {
    fn new() -> StTrie {
        let nodes = HashMap::new();
        let count = 0;
        StTrie { nodes, count }
    }

    fn len(&self) -> usize {
        self.count
    }

    fn insert(&mut self, value: St) {
        if let Some(&true) = self.nodes.get(&value) {
            return;
        }

        self.count += 1;
        self.nodes.insert(value, true);
        let mut value = value;
        for _ in 1..value.len() {
            value = value.chop();
            if let Some(_) = self.nodes.get(&value) {
                return;
            }

            self.nodes.insert(value, false);
        }
    }

    fn find(&self, value: St) -> NodeKind {
        match self.nodes.get(&value) {
            None => NodeKind::None,
            Some(&t) => {
                if t {
                    NodeKind::Terminal
                } else {
                    NodeKind::Prefix
                }
            }
        }
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn empty() {
        let trie = init_trie(vec![]);

        assert_eq!(0, trie.len());
    }

    #[test]
    fn one_item_len_1() {
        let trie = init_trie(vec!["X"]);

        assert_eq!(1, trie.len());
    }

    #[test]
    fn two_items_len_2_shared_prefix() {
        let trie = init_trie(vec!["HI", "HA"]);

        assert_eq!(2, trie.len());
        assert_eq!(NodeKind::Prefix, find_trie(&trie, "H"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "HA"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "HI"));
    }

    #[test]
    fn two_items_len_3_no_shared_prefix() {
        let trie = init_trie(vec!["ABC", "DEF", "GHI"]);

        assert_eq!(3, trie.len());
        assert_eq!(NodeKind::Prefix, find_trie(&trie, "A"));
        assert_eq!(NodeKind::Prefix, find_trie(&trie, "AB"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "ABC"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "DEF"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "GHI"));
    }

    #[test]
    fn get_nonexistent_node() {
        let trie = init_trie(vec!["ABC"]);

        assert_eq!(NodeKind::None, find_trie(&trie, "X"));
    }

    #[test]
    fn add_nodes_multiple_times() {
        let trie = init_trie(vec!["AB", "AB", "ABC", "ABC"]);

        assert_eq!(2, trie.len());
        assert_eq!(NodeKind::Prefix, find_trie(&trie, "A"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "AB"));
        assert_eq!(NodeKind::Terminal, find_trie(&trie, "ABC"));
    }

    fn init_trie(items: Vec<&str>) -> StTrie {
        let mut trie = StTrie::new();
        for item in items {
            trie.insert(item.parse::<St>().unwrap());
        }

        trie
    }

    fn find_trie(trie: &StTrie, item: &str) -> NodeKind {
        trie.find(item.parse::<St>().unwrap())
    }
}
