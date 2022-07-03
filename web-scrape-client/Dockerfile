FROM node:16.13.1-alpine3.14

WORKDIR /app

COPY package.json /app
RUN npm install
COPY . .

COPY entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

ENTRYPOINT ["/entrypoint.sh"]
CMD ["npm", "run", "dev"]