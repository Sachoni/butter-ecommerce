function showForm(type) {
    const title = document.getElementById("form-title");
    title.textContent = type === "have" ? "Post What You Have" : "Post What You Need";
}

document.getElementById("tradeForm").addEventListener("submit", function(e) {
    e.preventDefault();

    const itemName = document.getElementById("itemName").value;
    const category = document.getElementById("category").value;
    const description = document.getElementById("description").value;

    const post = document.createElement("div");
    post.className = "post-card";
    post.innerHTML = `
    <h3>${itemName}</h3>
    <p><strong>Category:</strong> ${category}</p>
    <p>${description}</p>
  `;

    document.getElementById("posts").prepend(post);
    document.getElementById("tradeForm").reset();
});