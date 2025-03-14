function output(item) {
	const productContainer = document.getElementById('product-container');

    const productDiv = document.createElement('div');
    productDiv.classList.add('product');

    productDiv.innerHTML = `
        <img src="${item.product.img}" alt="Produs">
        <div class="product-details">
            <h3>${item.product.title}</h3>
            <div class="price">Price per unit: ${item.product.price.toFixed(2)} EUR</div>
        </div>
        <div class="product-actions">
            <input type="number" value="1" min="1" id="quantity-${item.product.id}">
            <br>
            <button onclick="buyProduct(${item.product.id}, ${item.product.price})">Buy</button>
        </div>
    `;

    productContainer.appendChild(productDiv); 
}
	let total = 0;
    let totalElement;

function buyProduct(id, price) {
    const quantityInput = document.getElementById('quantity-' + id); 
	let quantity = parseFloat(quantityInput.value);

    if (!isNaN(quantity) && quantity > 0) {
        const subtotal = price * quantity; 
        total += subtotal; 
        totalElement.textContent = `Total: ${total.toFixed(2)} EUR`; 
    } else {
        alert('Please enter a valid quantity!');
	}
}

document.addEventListener('DOMContentLoaded', () => {
    totalElement = document.getElementById('total');
    cart.forEach(item => output(item));
});

