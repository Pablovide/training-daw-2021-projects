<template>
  <div style="margin: 0 auto; max-width: 20rem" class="">
    <div v-for="product in selectedProducts" v-bind:key="product.id">
      <div class="d-flex">
        <b-button>Delete</b-button>
        <div>{{ product.name }}</div>
        <div>{{ product.qtity }}</div>
        <div class="d-flex flex-column">
          <b-button>+</b-button>
          <b-button>-</b-button>
        </div>
        <div>${{ product.price * product.qtity }}</div>
      </div>
    </div>
    <div class="d-flex justify-content-between">
      <div>TOTAL</div>
      <div>${{ totalPrice }}</div>
    </div>
    <b-button variant="primary">Checkout</b-button>
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
    };
  },
};
</script>

<style>
</style>