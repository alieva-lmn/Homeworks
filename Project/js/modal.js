document.addEventListener('DOMContentLoaded', function () {
    const modal = document.getElementById('modal');
    const modalImage = document.getElementById('modal-image');
    const modalTitle = document.getElementById('modal-title');
    const modalDescription = document.getElementById('modal-description');
    const closeBtn = document.getElementsByClassName('close')[0];

    if (closeBtn) {
        closeBtn.addEventListener('click', function () {
            modal.style.display = 'none';
        });
    }

    const products = document.querySelectorAll('.box');

    products.forEach(product => {
        const viewDetailsBtn = product.querySelector('.cart-btn');
        const productId = product.getAttribute('data-product-id');
        const productName = product.querySelector('h3').textContent;
        const productImage = product.querySelector('img').getAttribute('src');
        const productDescription = product.querySelector('p').textContent;

        viewDetailsBtn.addEventListener('click', function (event) {

            event.preventDefault();

            modalTitle.textContent = productName;
            modalImage.src = productImage;
            modalDescription.textContent = productDescription;

            modal.style.display = 'block';
        });
    });

    window.addEventListener('click', function (event) {
        if (event.target === modal) {
            modal.style.display = 'none';
        }
    });
});
