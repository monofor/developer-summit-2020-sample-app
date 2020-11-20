<template>
  <div class="col">
    <div class="card mr-1">
      <div class="card-body">
        <h5 class="card-title">{{ product.name }}</h5>
        <p class="card-text">Code: {{ product.code }}</p>
        <input type="text" class="form-control mb-1" placeholder="Quantity" v-model="quantity"/>
        <button type="button" class="btn btn-block btn-primary" @click="order(product)">Order</button>
      </div>
    </div>
  </div>
</template>

<script>
import Service from "@/services/order";

export default {
  name: "Product",
  props: {
    product: {
      type: Object
    },
    index: {
      type: Number
    }
  },
  data() {
    return {
      quantity: 0
    }
  },
  methods: {
    async order(product) {
      const productId = product.productId;
      const data = [{
        productId: productId,
        quantity: parseInt(this.quantity)
      }];

      try {
        const result = await Service.post(data);

        alert(result.data.message);

        if (result.data.success) this.quantity = 0;
      } catch (e) {
        alert(e);
        console.error(e);
      }
    }
  }
}
</script>

<style scoped>

</style>