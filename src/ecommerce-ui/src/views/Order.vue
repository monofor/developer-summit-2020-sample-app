<template>
  <div class="table-responsive">
    <table class="table">
      <thead>
      <tr>
        <th>#</th>
        <th>Id</th>
        <th>Created</th>
        <th>Status</th>
        <th>Product Count</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="(order, index) of orders" :key="order.orderId">
        <td>{{ index + 1 }}</td>
        <td>{{ order.orderId }}</td>
        <td>{{ order.createdDate }}</td>
        <td>{{ order.statusText }}</td>
        <td>{{ order.details.length }}</td>
      </tr>
      </tbody>
    </table>
  </div>
</template>
<script>
import Service from "@/services/order";

export default {
  data() {
    return {
      orders: []
    }
  },
  async mounted() {
    await this.getOrders();
  },
  methods: {
    async getOrders() {
      try {
        const result = await Service.get();

        if (result.data.success) this.orders = result.data.data;
      } catch (e) {
        alert(e);
        console.error(e);
      }
    }
  }
}
</script>
