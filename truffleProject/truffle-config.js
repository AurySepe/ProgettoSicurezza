module.exports = {
  networks: {
    development: {
      host: "127.0.0.1",
      port: 7545,
      network_id: "*" // Match any network id
    }
   },
  compilers: {
    solc: {
      version: "0.8.17",
      docker: false,
      parser: "solcjs",
      settings: {
       optimizer: {
         enabled: true,
         runs: 200
       },
       evmVersion: "byzantium"
      }
    }
  },
    develop: {
      port: 7545
    }
};
