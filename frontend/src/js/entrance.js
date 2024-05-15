document.getElementById('entrance').addEventListener('click', function() {
    var name = document.getElementById('login').value;
    var password = document.getElementById('password').value;

    // Update the URL to include login and password as query parameters
    var url = 'http://localhost:5143/api/user/authorization?login=' + encodeURIComponent(name) + '&password=' + encodeURIComponent(password);

    fetch(url)
      .then(function(response) {
           if (!response.ok) {
               throw new Error("HTTP error " + response.status);
           }
           return response.json();
       })
      .then(function(data) {
           console.log(data);
       })
      .catch(function(error) {
           console.error('Error:', error);
       });
});