// Обработчик добавления товара в корзину
document.querySelectorAll(".add-to-cart").forEach(button => {
    button.addEventListener("click", function() {
        const productId = this.getAttribute("data-id");

        // AJAX-запрос для добавления товара в корзину
        fetch(`/Cart/Add?id=${productId}`, {
            method: 'GET'
        })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                // Обновляем количество товаров в корзине
                document.querySelector("#cart-count").textContent = data.cartCount;
                alert("Товар добавлен в корзину!");
            }
        });
    });
});
