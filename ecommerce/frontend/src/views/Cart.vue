<template>
  <div>
    <div v-if="checkoutDone">
      <p>Producto comprado con éxito</p>
      <router-link :to="{ name: 'Home' }"
        ><b-button variant="primary">Volver</b-button></router-link
      >
    </div>
    <div v-else style="margin: 0 auto; max-width: 30rem" class="">
      <div
        v-for="product in selectedProducts"
        v-bind:key="product.id"
        style="margin-bottom: 2em"
      >
        <div
          class="d-flex"
          style="align-items: center; justify-content: space-around"
        >
          <b-button style="height: 50%" v-on:click="deleteProduct(product)"
            >Delete</b-button
          >
          <div>{{ product.name }}</div>
          <div>{{ product.qtity }}</div>
          <div class="d-flex flex-column" style="gap: 0.5em">
            <b-button v-on:click="addProductToCart(product)">+</b-button>
            <b-button v-on:click="removeProductFromCart(product)">-</b-button>
          </div>
          <div>${{ product.price * product.qtity }}</div>
        </div>
      </div>
      <div class="d-flex justify-content-center" style="gap: 1em">
        <div>TOTAL</div>
        <div>${{ totalPrice }}</div>
      </div>
      <!--TODO-->
      <b-button variant="primary" v-on:click="checkout()">Checkout</b-button>
    </div>
  </div>
</template>

<script>
export default {
  created() {
    fetch(
      `${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/cart/0`
    )
      .then((response) => response.json())
      .then((json) => {
        this.cart = json;
        this.productList = this.cart.products;
        this.productList.forEach((element) => {
          if (
            this.selectedProducts.find((product) => product.id === element.id)
          ) {
            this.selectedProducts.find(
              (product) => product.id === element.id
            ).qtity += 1;
            this.totalPrice += parseInt(element.price);
          } else {
            this.selectedProducts.push({
              id: element.id,
              name: element.name,
              price: element.price,
              qtity: 1,
            });
            this.totalPrice += parseInt(element.price);
          }
        });
      });
  },
  data() {
    return {
      cart: {},
      productList: [],
      selectedProducts: [],
      totalPrice: 0,
      checkoutDone: false,
    };
  },
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
            products: this.productList,
          }),
        }
      );
    },
    putProduct(product) {
      this.productList.push(product);
      this.totalPrice += parseInt(product.price);
      this.selectedProducts.find(
        (element) => element.id === product.id
      ).qtity += 1;
    },
    removeProductFromCart(product) {
      this.removeProduct(product);
      fetch(
        `${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/cart/0`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            id: 0,
            products: this.productList,
          }),
        }
      );
    },
    removeProduct(product) {
      if (
        this.selectedProducts.find((element) => element.id === product.id)
          .qtity > 0
      ) {
        this.productList.splice(this.productList.indexOf(product), 1);
        this.selectedProducts.find(
          (element) => element.id === product.id
        ).qtity -= 1;
        this.totalPrice -= product.price;
      }
    },
    deleteProduct(product) {
      this.productList = this.productList.filter(
        (element) => element.id !== product.id
      );
      this.totalPrice -=
        this.selectedProducts.find((element) => element.id === product.id)
          .price *
        this.selectedProducts.find((element) => element.id === product.id)
          .qtity;
      this.selectedProducts = this.selectedProducts.filter(
        (element) => element.id !== product.id
      );
      fetch(
        `${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/cart/0`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            id: 0,
            products: this.productList,
          }),
        }
      );
    },
    checkout() {
      this.checkoutDone = true;
      fetch(
        `${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/orders/`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            products: this.productList,
          }),
        }
      );
      fetch(
        `${process.env.VUE_APP_API_SCHEMA}://${process.env.VUE_APP_API_URL}/cart/0`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            id: 0,
            products: [],
          }),
        }
      );
    },
  },
};
</script>

<style>
</style>