<template>
  <div id="app">
    <navigation-bar></navigation-bar>
    <div class="container-fluid body-content">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
  import NavigationBar from '@/components/NavigationBar'

  export default {
    name: 'app',
    components: {
      NavigationBar
    }
  }
</script>
