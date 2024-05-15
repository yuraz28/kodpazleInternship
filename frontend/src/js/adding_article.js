document.getElementById('categoryButton').addEventListener('click', function() {
    var categoryButtons = document.getElementById('categoryButtons');
    if (categoryButtons.style.display === 'none') {
        categoryButtons.style.display = 'flex';
        categoryButtons.classList.add('fadeIn');
    } else {
        categoryButtons.style.display = 'none';
        categoryButtons.classList.remove('fadeIn');
    }
});

// Создаем массив для хранения ссылок на input элементы
var inputs = [];

var buttons = document.querySelectorAll('#categoryButtons button');
buttons.forEach(function(button) {
    button.addEventListener('click', function() {
        var articleText = document.querySelector('.article_text');
        var newInput = document.createElement('input');
        newInput.type = 'text';
        newInput.id = 'input' + this.id;
        newInput.placeholder = this.textContent;
        newInput.style.outline  = 'none';
        newInput.style.fontSize  = '20px';

        // Вставляем новый input в конец блока article_text
        articleText.appendChild(newInput);
        inputs.push(newInput); // Добавляем ссылку на новый input в массив
        newInput.focus();
        
        // Ставим фокус на новом input'е
        var categoryButtons = document.getElementById('categoryButtons');
        categoryButtons.style.display = 'none';
        categoryButtons.classList.remove('fadeIn'); 
        
        newInput.addEventListener('keydown', function(event) {
            if (event.key === 'Enter') {
                event.preventDefault();
                var textContent = newInput.value.trim();
                if (textContent === '') {
                    var newLine = document.createElement('br');
                    articleText.appendChild(newLine);
                } else {    
                    var newElement;
                    if (newInput.id === 'inputh1') {
                        newElement = document.createElement('h1');
                        newElement.style.fontSize = '20px';
                        newElement.style.fontWeight = 'bold';
                    } else if (newInput.id === 'inputli') {
                        newElement = document.createElement('li');
                        newElement.textContent = textContent;
                        var ul = document.createElement('ul');
                        ul.appendChild(newElement);
                        articleText.appendChild(ul);
                    } else {
                        newElement = document.createElement('p');
                        newElement.textContent = textContent;
                    }
                    if (newInput.id !== 'inputli') {
                        newElement.textContent = textContent;
                        articleText.appendChild(newElement);
                    }
                }
                // Удаляем input после создания элемента
                newInput.parentNode.removeChild(newInput);
            }
        });
    });
});

// Обновляем логику добавления нового абзаца при нажатии Enter
document.getElementById('article_text').addEventListener('keydown', function(event) {
    if (event.key === 'Enter') {
        event.preventDefault();
        var articleText = document.querySelector('.article_text');
        var textContent = articleText.querySelector('input').value;
        if (textContent.trim() === '') {
            var newLine = document.createElement('br');
            articleText.appendChild(newLine);
        } else {    
            var newParagraph = document.createElement('p');
            newParagraph.textContent = textContent;
            articleText.appendChild(newParagraph);
        }
        // Очищаем содержимое текущего input'а
        articleText.querySelector('input').value = '';
        // Очищаем содержимое всех остальных input'ов
        inputs.forEach(function(input) {
            if (input!== articleText.querySelector('input')) {
                input.value = '';
            }
        });
    }
});
