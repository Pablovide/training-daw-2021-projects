<template>
  <div class="home">
    <div>Listado de productos</div>
    <div class="d-flex justify-content-center">
      <div>
        <ul
          id="productGrid"
          class="d-flex flex-wrap justify-content-center mt-2"
          style="list-style: none"
        >
          <li v-for="product in itemsForList" v-bind:key="product.id">
            <b-card
              :title="product.name"
              :img-src="product.mainImage"
              :img-alt="product.name"
              tag="article"
              style="max-width: 20rem"
              class="m-3"
            >
              <b-card-text>{{ product.short }}</b-card-text>
              <b-card-text style="font-weight: bold; text-align: end"
                >${{ product.price }}</b-card-text
              >
              <div class="d-flex justify-content-center" style="gap: 0.5rem">
                <router-link
                  :to="{ name: 'Product', params: { id: product.id } }"
                  ><b-button variant="primary">View</b-button></router-link
                >
                <b-button
                  variant="primary"
                  v-on:click="addProductToCart(product)"
                  >Add</b-button
                >
              </div>
            </b-card>
          </li>
        </ul>
        <b-pagination v-model="currentPage" align="center" aria-controls="productGrid" :total-rows="products.length" :per-page="perPage"></b-pagination>

      </div>
      <div class="w-25">
        <b-card
          title="Carrito"
          class="mt-3"
          style="height: inherit; width: 20rem"
        >
          <div v-for="product in selectedProducts" v-bind:key="product.id">
            <div class="d-flex justify-content-between">
              <div>{{ product.name }}</div>
              <div>${{ product.price }}</div>
            </div>
          </div>
          <div class="d-flex justify-content-between">
            <div>TOTAL</div>
            <div>${{ totalPrice }}</div>
          </div>
          <router-link :to="{ name: 'cart' }"
            ><b-button variant="primary">Checkout</b-button></router-link
          >
        </b-card>
      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
// import HelloWorld from '@/components/HelloWorld.vue'
export default {
  name: "Home",
  created() {
    fetch(
      `${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/products/`
    )
      .then((response) => response.json())
      .then((json) => {
        this.products = json;
      });
    fetch(
      `${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/cart/0`
    )
      .then((response) => response.json())
      .then((json) => {
        json.products.forEach((product) => {
          this.putProduct(product);
        });
      });
  },

  data() {
    return {
      get itemsForList() {
        return this.products.slice(
          this.currentPage * this.perPage,
          (this.currentPage + 1) * this.perPage
        );
      },
      products: [],
      selectedProducts: [],
      totalPrice: 0,
      currentPage: 1,
      perPage: 9,
    };
  },
  components: {},
  methods: {
    addProductToCart(product) {
      this.putProduct(product);
      fetch(
        `${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/cart/0`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            id: 0,
            products: this.selectedProducts,
          }),
        }
      );
    },
    putProduct(product) {
      this.selectedProducts.push(product);
      this.totalPrice += parseInt(product.price);
    },
  },
};
</script>
