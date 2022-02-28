<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <div>Listado de productos</div>
    <div class="d-flex justify-content-center">
      <div class="d-flex flex-wrap justify-content-center mt-2 w-75">
        <b-card
          v-for="product in products"
          v-bind:key="product.id"
          :title="product.name"
          :img-src="product.mainImage"
          :img-alt="product.name"
          tag="article"
          style="max-width: 20rem"
          class="m-3"
        >
          <b-card-text>{{ product.short }}</b-card-text>
          <div class="d-flex justify-content-center" style="gap: 0.5rem">
            <b-button variant="primary">View</b-button>
            <b-button variant="primary" v-on:click="addProduct(product)">Add</b-button>
          </div>
        </b-card>
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
              <div>{{ product.price }}</div>
            </div>
          </div>
          <div class="d-flex justify-content-between">
            <div>TOTAL</div>
            <div>{{ totalPrice }}</div>
          </div>
          <b-button variant="primary">Checkout</b-button>
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
    fetch("http://localhost:3000/products")
      .then((response) => response.json())
      .then((json) => {
        this.products = json;
      });
  },
  data() {
    return {
      products: [],
      selectedProducts: [],
      totalPrice: 0
    };
  },
  components: {},
  methods: {
    addProduct(product) {
      this.selectedProducts.push(product);
      this.totalPrice += parseInt(product.price);
    },
    removeProduct(product) {
      this.selectedProducts.splice(this.selectedProducts.indexOf(product), 1);
      this.totalPrice -= parseInt(product.price);
    },
  },
};
</script>
