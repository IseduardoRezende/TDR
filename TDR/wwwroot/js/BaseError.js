function translateErrors() {
    const errorElements = document.querySelectorAll('.text-danger-base-error');

    errorElements.forEach(element => {
        const textToTranslate = element.innerText;

        fetch(`https://api.mymemory.translated.net/get?q=${encodeURIComponent(textToTranslate)}&langpair=en-GB|pt-BR`)
            .then(response => response.json())
            .then(data => {
                const translatedText = data.responseData.translatedText;
                element.innerText = translatedText;
            })
            .catch(error => console.error('Error during translation:', error));
    });
}

// Chame a função de tradução
translateErrors();