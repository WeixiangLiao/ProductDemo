import  { useEffect } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import { useSelector, useDispatch } from 'react-redux';
import { getAllBuyers } from "../Infrastructure/Redux/BuyerReducer";
import { useParams, useNavigate } from 'react-router-dom';
import { getProductById } from "../Infrastructure/Redux/ProductReducer"

const UpdateProduct = () => {
    const { id } = useParams();
    const oldProduct = useSelector((state) => state.product.value);
    const buyers = useSelector(state => state.buyer.values);
    const dispatch = useDispatch();
    const navigate = useNavigate();

    useEffect(() => {
        dispatch(getAllBuyers());
        dispatch(getProductById(id));
    }

    , [dispatch, id]);

    if (!oldProduct) {
        return <div>Loading...</div>;
    }

    return (
        <div className="container mt-5">
            <h2>Update Product</h2>
            <Formik
                initialValues={{
                    id: oldProduct.id,
                    sku: oldProduct.sku,
                    title: oldProduct.title,
                    description: oldProduct.description,
                    buyerId: oldProduct.buyerId,
                    active: oldProduct.active
                }}
                validationSchema={Yup.object({
                    sku: Yup.string()
                        .required('SKU is required'),
                    title: Yup.string()
                        .required('Title is required'),
                    description: Yup.string()
                        .required('Description is required'),
                    buyerId: Yup.string()
                        .required('Buyer is required')
                })}
                onSubmit={(values, { setSubmitting }) => {
                    setTimeout(() => {
                        axios.put(`https://localhost:7030/Products/${id}`, values)
                            .then(response => {
                                console.log('Product updated:', response.data);
                                setSubmitting(false);
                                navigate("/Product/" + id)
                            })
                            .catch(error => {
                                console.error('Error updating product:', error);
                                setSubmitting(false);
                            });
                    }, 400);
                }}
            >
                {formik => (
                    <Form>
                        <div className="form-group">
                            <label htmlFor="sku">SKU</label>
                            <Field type="text" id="sku" name="sku" className="form-control" />
                            <ErrorMessage name="sku" component="div" className="text-danger" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="title">Title</label>
                            <Field type="text" id="title" name="title" className="form-control" />
                            <ErrorMessage name="title" component="div" className="text-danger" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="description">Description</label>
                            <Field as="textarea" id="description" name="description" className="form-control" />
                            <ErrorMessage name="description" component="div" className="text-danger" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="buyerId">Buyer</label>
                            <Field as="select" id="buyerId" name="buyerId" className="form-control">
                                <option value="">Select a buyer</option>
                                {buyers.map(buyer => (
                                    <option key={buyer.id} value={buyer.id}>{buyer.name}</option>
                                ))}
                            </Field>
                            <ErrorMessage name="buyerId" component="div" className="text-danger" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="active">Active</label>
                            <Field type="checkbox" id="active" name="active" className="form-control" />
                        </div>
                        <button type="submit" className="btn btn-primary" disabled={formik.isSubmitting}>Update</button>
                    </Form>
                )}
            </Formik>
        </div>
    );
};

export default UpdateProduct;