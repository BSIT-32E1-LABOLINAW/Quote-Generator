async function generateRandomQuote() {
    // Clear any existing quote
    document.getElementById('quoteText').textContent = '';
    document.getElementById('quoteAuthor').textContent = '';

    try {
        // Fetch a random quote from the Quotable API
        const response = await fetch('https://api.quotable.io/random');
        const data = await response.json();

        // Update the quote text and author on the page
        document.getElementById('quoteText').textContent = data.content;
        document.getElementById('quoteAuthor').textContent = data.author;

        // Display the quote
        document.getElementById('quote').style.display = 'block';
    } catch (error) {
        console.error('Error:', error);
    }
}

function generateQuoteByKeyword() {
    // Get the selected keyword from the dropdown menu
    var selectedKeyword = document.getElementById("keywordSelect").value;

    // Call the fetchQuoteByKeyword function passing the selected keyword
    fetchQuoteByKeyword(selectedKeyword);
}

// Function to fetch a quote based on the selected keyword
async function fetchQuoteByKeyword(keyword) {
    try {
        // Make an HTTP GET request to fetch a quote based on the selected keyword
        const response = await fetch(`https://api.quotable.io/random?tags=${keyword}`);

        if (response.ok) {
            // Parse the JSON response
            const data = await response.json();

            // Update the HTML elements with the fetched quote data
            document.getElementById("quoteText").textContent = data.content;
            document.getElementById("quoteAuthor").textContent = data.author;
            document.getElementById("quote").style.display = "block";
        } else {
            console.error("Failed to fetch quote:", response.statusText);
        }
    } catch (error) {
        console.error("Error:", error);
    }
}

async function browseQuotes() {
    try {
        // Fetch up to 10 quotes from the Quotable API
        const response = await fetch('https://api.quotable.io/quotes?limit=10');
        const data = await response.json();

        // Clear existing quotes
        document.getElementById('quoteList').innerHTML = '';

        // Display quotes in the list
        data.results.forEach(quote => {
            const listItem = document.createElement('li');
            listItem.classList.add('quoteItem', 'list-group-item');
            const link = document.createElement('a');
            link.classList.add('quoteLink');
            link.innerHTML = `<span>${quote.content}</span> <span class="quoteAuthor">- ${quote.author}</span>`;
            link.onclick = function () {
                displayQuoteDetails(quote);
            };
            listItem.appendChild(link);
            document.getElementById('quoteList').appendChild(listItem);
        });
    } catch (error) {
        console.error('Error:', error);
    }
}

// When quote is pressed it will show in the quote generator box
function displayQuoteDetails(quote) {
    // Update the displayed quote
    document.getElementById('quoteText').textContent = quote.content;
    document.getElementById('quoteAuthor').textContent = quote.author;
    // Show the quote
    document.getElementById('quote').style.display = 'block';
}

// Function to copy quote text to clipboard
function copyQuoteToClipboard() {
    const quoteText = document.getElementById('quoteText').textContent;
    const tempTextArea = document.createElement('textarea');
    tempTextArea.value = quoteText;
    document.body.appendChild(tempTextArea);
    tempTextArea.select();
    document.execCommand('copy');
    document.body.removeChild(tempTextArea);
    alert('Quote copied to clipboard!');
}

// Load initial quotes when the page is loaded
window.onload = function () {
    browseQuotes();
    generateRandomQuote(); 
};
