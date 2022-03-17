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
            <EProduct :product="product"></EProduct>
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
          <div v-for="product in $store.getters.cartItems" v-bind:key="product.id">
            <div class="d-flex justify-content-between">
              <div>{{ product.name }}</div>
              <div>${{ product.price }}</div>
            </div>
          </div>
          <div class="d-flex justify-content-between">
            <div>TOTAL</div>
            <div>${{ $store.state.totalPrice }}</div>
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
// import store from '../store/index.js'
import EProduct from "../components/EProduct.vue";
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
      totalPrice: 0,
      currentPage: 1,
      perPage: 9,
    };
  },
  components: {
    EProduct
  },
  methods: {
  },
};
</script>
