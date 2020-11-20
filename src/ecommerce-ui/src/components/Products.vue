<template>
  <div class="row">
    <template v-for="(product, index) in products">
      <Product :product="product" :index="index" :key="product.productId" />
    </template>
  </div>
</template>

<script>
import Product from "./Product";
import Service from "@/services/product";

export default {
  name: "Products",
  components:{
    Product
  },
  data() {
    return {
      products: []
    }
  },
  async mounted() {
    await this.getProducts();
  },
  methods: {
    async getProducts() {
      try {
        const result = await Service.get();

        if (result.data.success) {
          this.products = result.data.data;
        } else {
          alert(result.data.message);
        }
      } catch (e) {
        alert(e);
        console.error(e);
      }
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
