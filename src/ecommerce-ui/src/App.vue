<template>
  <div id="app">
    <nav-bar/>
    <div class="col-6 mx-auto mt-1">
      <router-view/>
    </div>
  </div>
</template>
<script>
import NavBar from "@/components/NavBar";

export default {
  components: {
    NavBar
  }
}
</script>

<style>

</style>
