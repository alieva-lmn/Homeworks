document.addEventListener('DOMContentLoaded', function () { 
    const btnThemeToggleOff = document.querySelector('.btnTheme-toggle-off');

    btnThemeToggleOff.addEventListener('click', function (event) {

        event.preventDefault();

        const iconElement = btnThemeToggleOff.querySelector('a');
        const currentTheme = document.documentElement.getAttribute('data-theme');
        const newTheme = (currentTheme === 'light') ? 'dark' : 'light';

        if (currentTheme === 'light') {
            iconElement.classList.remove('fa-toggle-off');
            iconElement.classList.add('fa-toggle-on');
        } else {
            iconElement.classList.remove('fa-toggle-on');
            iconElement.classList.add('fa-toggle-off');
        }

        document.documentElement.setAttribute('data-theme', newTheme);
    });
    
});