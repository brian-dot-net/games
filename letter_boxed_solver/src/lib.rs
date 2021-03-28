pub fn hello(name: &str) -> String {
    format!("Hello, {}!", name)
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn say_hello() {
        assert_eq!("Hello, there!", hello("there"));
    }
}