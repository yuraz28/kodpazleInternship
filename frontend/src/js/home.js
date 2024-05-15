document.addEventListener('DOMContentLoaded', function() {
    var filterButton = document.getElementById('filter_button');
    var menuListFilter = document.getElementById('menu_list_filter');

    filterButton.addEventListener('click', function() {
        if (menuListFilter.style.display === "none") {
            menuListFilter.style.display = "block";
        } else {
            menuListFilter.style.display = "none";
        }
    });
});