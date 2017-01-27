module.exports = {
    entry: './app/main.ts',
    output: {
        filename: 'bundle.js',
        path: './app/'
    },
    module: {
      loaders: [
        { test: /\.css$/, loader:'style!css!' },
        { test: /\.html$/, loader: "html" }
      ],
    }
}