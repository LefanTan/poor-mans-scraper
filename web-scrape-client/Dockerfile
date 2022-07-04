FROM node:16.13.1-alpine3.14 as builder
WORKDIR /app

COPY package.json /app
RUN npm install
COPY . .
RUN npm run build

FROM node:16.13.1-alpine3.14 as final

RUN mkdir -p /home/node/app/build && chown -R node:node /home/node/app
WORKDIR /home/node/app

USER node

COPY package.json .
RUN npm install --only=prod
RUN npm install serve

COPY --chown=node:node --from=builder /app/dist ./dist

CMD ["npm", "run", "serve"]